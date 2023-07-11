using Ozone.Application.DTOs;
using Ozone.Application.Constants;
using Ozone.Infrastructure.Persistence;
using Ozone.Application.DTOs.Authenticaion;
using Ozone.Application.Helpers;
//using Ozone.Application.Interfaces;
//using Ozone.Application.Interfaces.Service;
//using Ozone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ozone.Infrastructure.Persistence.Models;
using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Service;
using Ozone.Application;
using Ozone.Application.Repository;
using AutoMapper;
//using Ozone.Infrastructure.Persistence.Repository;

namespace Ozone.Infrastructure.Shared.Services

{
    public class COIAuthenticationService : GenericRepositoryAsync<SecUser>, ICOIAuthenticationService
    {
        //ILocationRepositoryAsync _locationRepository;
        // ISecUserRepositoryAsync _secUserRepository;
        //ISecUserSessionRepositoryAsync _secUserSessionRepository;
        //ISecUserInvalidAccessRepositoryAsync _secUserInvalidAccessRepository;
        private readonly OzoneContext _context;
        ISecPolicyService _secPolicyService;
        private IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public COIAuthenticationService(
             IMapper mapper,
            // ILocationRepositoryAsync locationRepository,
            // ISecUserRepositoryAsync secUserRepo,
            // ISecUserSessionRepositoryAsync secUserSessionRepo,
            // ISecUserInvalidAccessRepositoryAsync secUserInvalidAccessRepository,
            ISecPolicyService secPolicyService,
            IUnitOfWork unitOfWork, OzoneContext context
            ) : base(context)
        {
            //  this._locationRepository = locationRepository;
            // this._secUserRepository = secUserRepo;
            // this._secUserSessionRepository = secUserSessionRepo;
            // this._secUserInvalidAccessRepository = secUserInvalidAccessRepository;
            this._secPolicyService = secPolicyService;
            this._unitOfwork = unitOfWork;
            _context = context;
            this._mapper = mapper;
        }



        public async Task<LoginResultModel> AuthenticateUser(LoginModel model)
        {
            // OSMSTestContext dbTestContext = new OSMSTestContext();
            //var test = (await Task.Run(() =>.SecUser.Where(x => x.UserName == model.Username).FirstOrDefaultAsync()));

            OzoneContext dbContext = new OzoneContext();

            var user = new SecUserModel();
            // SecUser user = new SecUser();
            // user = (await _context.SecUser.Where(x => x.UserName == model.Username).FirstOrDefaultAsync());
            // var list = await Task.Run(() => _context.SecUser.Where(x => x.IsClosed == false && x.IsAuthorized == true).ToList());
            //var userdata = await Task.Run(() => _context.SecUser.Include(x=>x.Organization).Where(x =>x.UserName==model.Username && x.IsClosed == false && x.ApprovelStatusId==2).FirstOrDefault());
            var userdata = await Task.Run(() => _context.SecUser.Where(x => x.UserName == model.Username && x.IsClosed == false ).FirstOrDefault());

            user = _mapper.Map<SecUserModel>(userdata);
            //user = (await Task.Run(() => (from secusers in _context.SecUser
            //                              where secusers.UserName == model.Username && secusers.IsDeleted==false
            //                              select new SecUser
            //                              {
            //                                  Id = secusers.Id,
            //                                  UserName = secusers.UserName,
            //                                  SecurityKey = secusers.SecurityKey,
            //                                  Password = secusers.Password,
            //                                  IsAuthorized = secusers.IsAuthorized,
            //                                  IsActive = secusers.IsActive,
            //                                  IsClosed = secusers.IsClosed,
            //                                  AccessFailedCount = secusers.AccessFailedCount,
            //                                  RoleId = secusers.RoleId,
            //                                  Email = secusers.Email,
            //                                  LockedDateTime = secusers.LockedDateTime,
            //                                  OrganizationId = secusers.OrganizationId,
            //                                  UserTypeId = secusers.UserTypeId,
            //                                  FirstName=secusers.FirstName




            //                              }).FirstOrDefault()));

            // user = (from Us in dbContext.SecUser.Where(x => x.UserName == model.Username) select Us).FirstOrDefault();
            //var user = _secUserRepository.GetUserByUserName(model.Username);
            LoginResultModel result = new LoginResultModel();
            result.IsAuthenticated = false;
            result.Username = model.Username;
            if (user != null)
            {
                HashingHelper hashHelper = HashingHelper.GetInstance();

                string pwdHash = hashHelper.ComputeHash(model.Password, user.SecurityKey);
                // Is Password matched
                if (pwdHash != user.Password)
                    result.Message = "Invalid Username or Password";

                // Is user not authorized
                if (user.IsAuthorized == null || !user.IsAuthorized.Value)
                    result.Message = "User is not authorized";

                // Is user active
                if (!user.IsActive.Value || user.IsClosed.Value)
                    result.Message = "User is not active";


                // Is Role Active
                // Is Department Active

                //If Other session already exist
                SecUserSession userSession = _context.SecUserSession.Where(sus => sus.SecUserId == user.Id).FirstOrDefault();
                // SecUserSession userSession = _secUserSessionRepository.GetSessionByUserId(user.Id);
                if (userSession != null && (userSession.LogoutDateTime != null || userSession.IsClosed))
                    result.Message = "User already logged in from another location";
            }
            else
                result.Message = "Invalid Username or Password";

            if (string.IsNullOrEmpty(result.Message))
            {
                result.IsAuthenticated = true;
                result.UserId = user.Id;
                result.RoleId = user.RoleId;
                result.Email = user.Email;
                result.OrganizationId = user.OrganizationId;
                result.UserTypeId = user.UserTypeId;
                result.FirstName = user.FullName;
                result.OrganizationName = user.OrganizationName;
                //result.LocationId = user.BaseLocationId.Value;
                // result.SbpAllowed = user.SbpAllowed;

                // var location = await _locationRepository.GetLocationById(user.BaseLocationId.Value);
                //if(location != null)
                //{
                //    result.LocationName = location.Name;
                //    result.LocationTypeId = location.LocationTypeId.Value;

                //}
                //else
                //{
                //    result.Message = "Location Not Found";
                //}

            }
            else
            {
                // If user is not authenticated due to user name / password, then add invalid access attempt
                if (result.Message == "Invalid Username or Password")
                {
                    if (user != null)
                    {
                        user.AccessFailedCount += 1;

                        List<SecPolicy> _secPolicyList = (await Task.Run(() => _context.SecPolicy.Where(sp => sp.IsClosed == false && sp.IsSubmitted == true && sp.IsAuthorized == true).ToList()));
                        var sPolicy = _secPolicyList.Where(sp => sp.Name == SecPolicyConstants.LockingIncorrectAttempts).FirstOrDefault();


                        // SecPolicyModel sPolicy = await _secPolicyService.GetLockingIncorrectAttemptsPolicy();
                        int incorrectAttempts = 0;
                        if (sPolicy != null && sPolicy.Value != null)
                            Int32.TryParse(sPolicy.Value, out incorrectAttempts);
                        if (incorrectAttempts > 0 && user.AccessFailedCount > incorrectAttempts)
                        {
                            user.IsActive = false;
                            user.LockedDateTime = DateTime.Now;
                        }
                        //  dbContext.Entry(users).State = System.Data.Entity.EntityState.Modified;

                        //_secUserRepository.UpdateUser(user);

                        SecUserInvalidAccess suInvalidAccess = new SecUserInvalidAccess();
                        suInvalidAccess.AccessDateTime = DateTime.Now;
                        suInvalidAccess.CreatedBy = 1;
                        suInvalidAccess.CreatedDate = DateTime.Now;
                        suInvalidAccess.IsClosed = false;
                        suInvalidAccess.SecUserId = user.Id;
                        suInvalidAccess.UserName = user.UserName;
                        // await base.AddAsync(suInvalidAccess);
                        dbContext.SecUserInvalidAccess.Add(suInvalidAccess);

                        //await _secUserInvalidAccessRepository.CreateInvalidAccessAttemp(suInvalidAccess);



                    }
                }
            }


            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<ResetPasswordModel> ResetPasswordCount(long userId)
        {
            ResetPasswordModel reset = new ResetPasswordModel();
            var result = await Task.Run(() => _context.ResetPasswordAccount.Where(sp => sp.UserId == userId && sp.IsDeleted == false).OrderByDescending(x=>x.Id).FirstOrDefault());
            // var result = await Task.Run(() =>  _context.ResetPasswordAccount.Where(sp => sp.UserId == userId && sp.IsDeleted==false).FirstOrDefault());
            reset = _mapper.Map<ResetPasswordModel>(result);
            return reset;
        }
        public async Task<string> CheckPermission(long id)
        {
            ResetPasswordModel reset = new ResetPasswordModel();
            var result = await Task.Run(() => _context.ResetPasswordAccount.Where(sp => sp.UserId == id && sp.IsDeleted == false).OrderByDescending(x => x.Id).FirstOrDefault());
            // var result = await Task.Run(() =>  _context.ResetPasswordAccount.Where(sp => sp.UserId == userId && sp.IsDeleted==false).FirstOrDefault());
            reset = _mapper.Map<ResetPasswordModel>(result);

            if (reset != null)
            {
                if (reset.UserId != reset.CreatedById)
                {
                    //Password Reset by another user
                    return "1";
                }



                else
                {
                    //Password changed by own user
                    return "2";
                }

            }
            else
            {  
                //First Time Login After create new User

                return "3";
            }
          

        }
    }
}
