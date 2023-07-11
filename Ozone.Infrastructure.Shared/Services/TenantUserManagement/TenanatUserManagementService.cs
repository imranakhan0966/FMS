using System.Runtime.CompilerServices;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using AutoMapper;
using Ozone.Application;
using Ozone.Application.Interfaces;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Sieve.Services;
using Sieve.Models;
using Ozone.Application.Helpers;

namespace Ozone.Infrastructure.Shared.Services
{
    public class TenanatUserManagementService : GenericRepositoryAsync<SecUser>, ITenanatUserManagementService
    {
        #region Fields
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;

        private readonly SieveProcessor _sieveProcessor;

        #endregion
        #region Ctor

        public TenanatUserManagementService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
         // IUserSessionHelper userSession,
         SieveProcessor sieveProcessor,
         IConfiguration configuration) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._sieveProcessor = sieveProcessor;
            //_mockData = mockData;
            this._configuration = configuration;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Gets All Users
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Users
        /// </returns>

        public async Task<List<SecUserModel>> GetAllUsers(AdvanceQueryParameter queryParameter)
        {
            var result = new List<SecUserModel>();
            var query = await Task.Run(() => _dbContext.SecUser.Include(x => x.Country).Include(x => x.State).Include(x => x.City).Include(x => x.Building).Where(x => x.IsDeleted == false && x.CountryId == 6));

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);

            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<SecUserModel>>(list);
            return result;
        }

        public async Task<SecUserModel> GetUserById(long userId)
        {
            var result = new SecUserModel();
            var obj = await Task.Run(() => _dbContext.SecUser.Where(x => x.Id == userId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<SecUserModel>(obj);
            return result;
        }

        /// <summary>
        /// Update a Building
        /// </summary>
        /// <param name="ClientId">Building Identifier</param>
        /// <param name="input">ServiceRequest object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateUserManagement(long id, UserDataWithFilesModel input)
        {
            var message = "";
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                SecUser userdb = null;
                SecUser sec_user = _dbContext.SecUser.Where(u => u.UserName == input.Email && u.IsDeleted == false).FirstOrDefault();
                if (id > 0)
                {
                    userdb = _dbContext.SecUser.Where(u => u.Id == id && u.IsDeleted == false).FirstOrDefault();


                }
                if (userdb == null && sec_user != null)
                {
                    message = "0";
                    return message;
                }
                else
                {
                    if (userdb == null && input.ConfirmPassword != input.Password)
                    {
                        message = "1";
                        return message;
                    }

                    try
                    {

                        userdb.UserName = input.Email;
                        userdb.FullName = input.FullName;
                        userdb.IsActive = true;//input.IsActive;
                        userdb.EmailForgotPassword = input.Email;
                        userdb.ApprovelStatusId = 2;
                        userdb.Email = input.Email;
                        userdb.UserTypeId = input.UserTypeId;
                        userdb.PrefixId = input.PrefixId;
                        userdb.ParentUserId = input.ParentUserId;
                        userdb.CountryId = input.CountryId;
                        userdb.CityId = input.CityId;
                        userdb.StateId = input.StateId;
                        userdb.BuildingId = input.BuildingId;
                        userdb.FloorId = input.FloorId;
                        userdb.FlatId = input.FlatId;
                        userdb.PostalCode = input.PostalCode;
                        userdb.RegistrationNo = input.RegistrationNo;
                        if (input.DateOfBirth != null && input.DateOfBirth != "")
                        {
                            userdb.DateOfBirth = Convert.ToDateTime(input.DateOfBirth);
                        }
                        userdb.Telephone = input.Telephone;
                        userdb.Mobile = input.Mobile;
                        userdb.Address1 = input.Address1;
                        userdb.Address2 = input.Address2;
                        userdb.Code = input.Code;
                        userdb.FirstName = input.FirstName;

                        userdb.EmailForgotPassword = input.EmailForgotPassword;
                        await base.UpdateAsync(userdb);
                        //Message = "Successfully Updated!";
                        message = "3";
                        await _unitOfWork.SaveChangesAsync();
                        transaction.Commit();
                        return message;
                    }
                    catch (Exception ex)
                    {
                        var Exception = ex;
                        transaction.Rollback();
                        message = "4";
                        return message;
                    }
                }
            }
        }

        public async Task<string> CreateUserManagement(UserDataWithFilesModel input)
        {

            var message = "";
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {

                SecUser userdb = null;
                SecUser sec_user = _dbContext.SecUser.Where(u => u.UserName == input.Email && u.IsDeleted == false).FirstOrDefault();

                if (userdb == null && sec_user != null)
                {
                    //return "User Already Exists!";
                    message = "0";
                    return message;
                }
                else
                {

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                    if (userdb == null && input.ConfirmPassword != input.Password)
                    {
                        //return "Password doesn't match Confirm Password"; 
                        message = "1";
                        return message;
                    }

                    try
                    {
                        // var Message="";
                        long newid;
                        bool New = false;
                        if (userdb == null)
                        {
                            New = true;
                            userdb = new SecUser();


                        }
                        // SecUser secuserEntity = new SecUser();

                        userdb.UserName = input.Email;
                        userdb.FullName = input.FullName;
                        userdb.LastName = input.LastName;
                        //userdb.DepartmentId = input.DepartmentId;
                        userdb.IsActive = true;//input.IsActive;
                        if (input.RoleId != 24)
                        {
                            userdb.RoleId = 23;
                        }
                        else
                        {
                            userdb.RoleId = 24;
                        }
                        userdb.ApprovelStatusId = 2;
                        userdb.Email = input.Email;
                        userdb.UserTypeId = input.UserTypeId;
                        userdb.PrefixId = input.PrefixId;
                        userdb.ParentUserId = input.ParentUserId;
                        userdb.CountryId = input.CountryId;
                        userdb.CityId = input.CityId;
                        userdb.StateId = input.StateId;
                        userdb.BuildingId = input.BuildingId;
                        userdb.FloorId = input.FloorId;
                        userdb.FlatId = input.FlatId;
                        userdb.PostalCode = input.PostalCode;
                        userdb.RegistrationNo = input.RegistrationNo;

                        if (input.DateOfBirth != null && input.DateOfBirth != "")
                        {
                            userdb.DateOfBirth = Convert.ToDateTime(input.DateOfBirth);
                        }
                        userdb.Telephone = input.Telephone;
                        userdb.Mobile = input.Mobile;
                        userdb.Address1 = input.Address1;
                        userdb.Address2 = input.Address2;
                        userdb.Code = input.Code;
                        userdb.FirstName = input.FirstName;

                        userdb.EmailForgotPassword = input.Email;


                        // secuserEntity.Designation = input.Designation;

                        if (New == true)
                        {
                            EmailSending emailSending = new EmailSending(_configuration);
                            var response = emailSending.EmailRequest(input.Email, "Congratulations!" + "\n" + "Mr/Miss: " + input.FullName + " " + input.FirstName, "Your (Maintenance Manager) Account is Generated on Activo-FMS", "Your UserName: " + input.Email + " and your Password:" + input.Password + "\n" + "Thanks Best Regards" + "\n" + "Activo-FMS");
                            if (!response.Contains("successfully Send"))
                            {
                                return message = "4";
                            }
                            userdb.Password = input.Password;
                            HashingHelper hashHelper = HashingHelper.GetInstance();
                            string securityKey = string.Empty;
                            string pwdHash = hashHelper.GenerateHash(userdb.Password, ref securityKey);
                            userdb.Password = pwdHash;
                            userdb.SecurityKey = securityKey;
                            // secuserEntity.BaseLocationId = input.BaseLocationId;
                            userdb.ProfileExpiryDate = null;
                            userdb.AccessFailedCount = 0;
                            userdb.LockedDateTime = null;
                            userdb.CreatedBy = 1;
                            userdb.CreatedDate = DateTime.Now;
                            userdb.PwdChangeDateTime = null;
                            userdb.ProfileExpiryDate = null;
                            userdb.RetirementDate = null;
                            userdb.IsDeleted = false;
                            userdb.IsAuthorized = true;
                            userdb.IsClosed = false;
                            userdb.OrganizationId = input.OrganizationId;
                            userdb.ClientId = input.ClientId;
                            await base.AddAsync(userdb);
                            // message = "Successfully Inserted!";
                            message = "2";
                        }


                        await _unitOfWork.SaveChangesAsync();
                        newid = userdb.Id;



                        transaction.Commit();
                        return message;

                    }
                    catch (Exception ex)
                    {
                        var Exception = ex;
                        transaction.Rollback();
                        message = "4";
                        return message;

                        //return "Not Inserted!";
                    }

                    //}
                    //else
                    //{
                    //    return "Password doesn't match Confirm Password";
                    //}

                }
            }
        }
        #endregion
    }
}
