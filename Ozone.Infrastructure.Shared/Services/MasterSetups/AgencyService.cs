using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Security;


//using Ozone.Domain.Entities;
using Ozone.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozone.Infrastructure.Persistence.Models;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Parameters;
using Ozone.Application.Interfaces;
//using Ozone.Infrastructure.Persistence.Repository;
using Ozone.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Ozone.Application.Repository;
using System.IO;
using Microsoft.Extensions.Configuration;
using Ozone.Application.Helpers;
//using AutoMapper.Configuration;
using System.Net.Mail;
using System.Net;
namespace Ozone.Infrastructure.Shared.Services
{
    public class AgencyService : GenericRepositoryAsync<Organization>, IAgensyService
    {

        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;
        public AgencyService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        IUserSessionHelper userSession, IConfiguration configuration) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._userSession = userSession;
            //_mockData = mockData;
            this._configuration = configuration;
        }

        public async Task<OrganizationModel> GetAgencyBYId(long id)
        {
            var result = new OrganizationModel();
            var Orgdata = await Task.Run(() => _dbContext.Organization.Where(x => x.Id == id).FirstOrDefault());
           // var Userdata = await Task.Run(() => _dbContext.SecUser.Where(x => x.OrganizationId == id && x.RoleId==6).FirstOrDefault());



            // result = _mapper.Map<OrganizationModel>(Orgdata);
            result.Name = Orgdata.Name;
            result.Description = Orgdata.Description;
            result.Code = Orgdata.Code;
            result.ContactNumber = Orgdata.ContactNumber;
            result.Email = Orgdata.Email;
            result.ContactPerson = Orgdata.ContactPerson;
         //   result.PersonContactNumber = OrgdataOrgdataPersonContactNumber;
            result.Address = Orgdata.Address;
            result.CountryId = Orgdata.CountryId;
            result.CityId = Orgdata.CityId;
            result.PostalCode = Orgdata.PostalCode;
            result.Address2 = Orgdata.Address2;
            result.StateId = Orgdata.StateId;
            result.JoiningDate =Orgdata.JoiningDate;
            result.IsActive = Orgdata.IsActive;

            var secUserdata = await Task.Run(() => _dbContext.SecUser.Where(x => x.OrganizationId == Orgdata.Id && x.RoleId==6 && x.IsDeleted==false && x.IsActive==true).FirstOrDefault());
            result.UserName = secUserdata.UserName;
            result.Password = secUserdata.Password;
            result.EmailForgotPassword = secUserdata.EmailForgotPassword;
            result.RoleId =secUserdata.RoleId;



            return result;
        }
        public async Task<List<SecRoleFormPagedModel>> GetAllRoles(long id)
        {
           // long roleid = await Task.Run(() => _dbContext.SecUser.Where(x => x.IsClosed == false && x.Id == id).Select(x => x.RoleId).FirstOrDefault());
            int? level = await Task.Run(() => _dbContext.SecRole.Where(x => x.IsClosed == false && x.Id == id).Select(x => x.UserLevel).FirstOrDefault());
            // await Task.Run(() => _context.SecRole.Where(x => x.IsClosed == false && x.IsAuthorized == true && x.UserLevel>level).ToList());
            var result = new List<SecRoleFormPagedModel>();
            //var list = await _secRoleRepository.GetRoles();
            //   OzoneContext _dbContext = new OzoneContext();
            var list = await Task.Run(() => _dbContext.SecRole.Where(x => x.IsClosed == false && x.IsAuthorized == true && x.UserLevel > level).ToList());
            result = _mapper.Map<List<SecRoleFormPagedModel>>(list);
            return result;
        }
        private List<OrganizationModel> GetPage(List<OrganizationModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<string> CreateAgency(OrganizationModel input)
        {
            var message = "";
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var Clientcode = await Task.Run(() => _dbContext.Organization.Where(x => x.Code == input.Code && x.Id != input.Id).Select(x=>x.Code).FirstOrDefault());
                if (Clientcode == null || Clientcode=="")
                {
                    Organization DbOrganization = null;
                    if (input.Id > 0)
                    {
                        DbOrganization = await Task.Run(() => _dbContext.Organization.Where(x => x.Id == input.Id && x.IsDeleted == false).FirstOrDefault());
                    }
                    SecUser DbUser = await Task.Run(() => _dbContext.SecUser.Where(x => x.UserName == input.UserName && x.IsDeleted == false).FirstOrDefault());

                    if (DbUser != null && DbOrganization == null)
                    {
                        //return "User Already Exists!";
                        message = "0";
                        return message;
                    }
                    else
                    {



                        try
                        {
                           // var message = "";
                            long newid;
                            bool New = false;
                            if (DbOrganization == null)
                            {
                                New = true;
                                DbOrganization = new Organization();
                            }

                            DbOrganization.Name = input.Name;
                            DbOrganization.Description = input.Description;
                            DbOrganization.Code = input.Code;
                            DbOrganization.ContactNumber = input.ContactNumber;
                            DbOrganization.Email = input.Description;
                            DbOrganization.ContactPerson = input.ContactPerson;
                            DbOrganization.PersonContactNumber = input.PersonContactNumber;
                            DbOrganization.Address = input.Address;
                            DbOrganization.CountryId = input.CountryId;
                            DbOrganization.CityId = input.CityId;
                            DbOrganization.PostalCode = input.PostalCode;
                            DbOrganization.Address2 = input.Address2;
                            DbOrganization.StateId = input.StateId;
                            if (input.JoiningDate != null)
                            {
                                DbOrganization.JoiningDate = Convert.ToDateTime(input.JoiningDate);
                            }


                            DbOrganization.OrganizationTypeId = 2;

                            DbOrganization.IsActive = input.IsActive;
                            if (New == true)
                            {

                                DbOrganization.CreationTime = DateTime.Now;
                                DbOrganization.CreatorUserId = input.CreatorUserId;
                                DbOrganization.IsDeleted = false;
                                await base.AddAsync(DbOrganization);
                                //message = "Successfully Inserted!";
                                message = "1";
                            }
                            else
                            {
                                if (input.IsDeleted == false) { DbOrganization.IsDeleted = input.IsDeleted; }

                                DbOrganization.LastModificationTime = DateTime.Now;
                                DbOrganization.LastModifierUserId = input.LastModifierUserId;

                                await base.UpdateAsync(DbOrganization);
                                // message = "Successfully Updated!";
                                message = "2";
                            }
                            await _unitOfWork.SaveChangesAsync();
                            //  for user
                            if (DbUser == null)
                            {
                                New = true;
                                DbUser = new SecUser();
                            }
                            // DbOrganization.SecUser = new SecUser();
                            DbUser.FirstName = input.ContactPerson;
                            DbUser.FullName = input.ContactPerson;
                            DbUser.UserName = input.UserName;
                            DbUser.UserTypeId = 2;


                            DbUser.UserName = input.UserName;
                            DbUser.FullName = input.ContactPerson;
                            //  DbUser.DepartmentId = input.DepartmentId;
                            DbUser.IsActive = input.IsActive;
                            DbUser.RoleId = input.RoleId.Value;
                            DbUser.IsClosed = false;
                            DbUser.Email = input.Email;

                            //DbUser.PrefixId = input.PrefixId;
                            DbUser.CountryId = input.CountryId;
                            DbUser.CityId = input.CityId;
                            DbUser.StateId = input.StateId;
                            DbUser.PostalCode = input.PostalCode;
                            //DbUser.RegistrationNo = input.RegistrationNo;
                            //DbUser.DateOfBirth = Convert.ToDateTime(input.DateOfBirth);
                            DbUser.Telephone = input.ContactNumber;
                            //DbUser.Mobile = input.Mobile;
                            DbUser.Address1 = input.Address;
                            DbUser.Address2 = input.Address2;
                            DbUser.Code = input.Code;
                            DbUser.RoleId = input.RoleId;
                            DbUser.IsDeleted = false;


                            DbUser.EmailForgotPassword = input.EmailForgotPassword;
                            if (New == true)
                            {
                                DbUser.Password = input.Password;
                                HashingHelper hashHelper = HashingHelper.GetInstance();
                                string securityKey = string.Empty;
                                string pwdHash = hashHelper.GenerateHash(input.Password, ref securityKey);
                                DbUser.Password = pwdHash;
                                DbUser.SecurityKey = securityKey;
                                // secuserEntity.BaseLocationId = input.BaseLocationId;
                                DbUser.ProfileExpiryDate = null;
                                DbUser.AccessFailedCount = 0;
                                DbUser.LockedDateTime = null;
                                DbUser.CreatedBy = 1;
                                DbUser.CreatedDate = DateTime.Now;
                                DbUser.PwdChangeDateTime = null;
                                DbUser.ProfileExpiryDate = null;
                                DbUser.RetirementDate = null;
                                newid = DbOrganization.Id;
                                DbUser.OrganizationId = newid;
                                DbUser.IsClosed = false;
                                DbUser.IsAuthorized = true;


                            }
                            if (New == true)
                            {
                                await _dbContext.AddAsync(DbUser);
                            }
                            else
                            {
                                _dbContext.Update(DbUser);
                            }


                            var senderEmail = new MailAddress("ozonepakistan2021@gmail.com", "Ozone Pakistan");
                            var receiverEmail = new MailAddress(input.EmailForgotPassword, "Receiver");
                            var password = "ozone2021";
                            var body = "";
                            // var sub = "Call Back Test";
                            if (New == true)
                            {
                                body = "Your account has been created in Ozone Portal, your Login Name:  " + input.UserName + ",   password:  " + input.Password;
                                //var body = " Your password has been changed, New password is:  " + input.Password;
                            }
                            else
                            {
                                body = " Your password has been changed,your Login Name:   " + input.UserName + ",   password is:  " + input.Password;
                            }
                            var smtp = new SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,

                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                //UseDefaultCredentials = true,

                                Credentials = new NetworkCredential(senderEmail.Address, password),
                                EnableSsl = true,
                            };
                            using (var mess = new MailMessage(senderEmail, receiverEmail)
                            {
                                Subject = "New Password",
                                Body = body
                            })
                            {
                                //  smtp.UseDefaultCredentials = false;
                                smtp.Send(mess);
                            }
                            var result = await _unitOfWork.SaveChangesAsync();



                            transaction.Commit();

                            return message;



                        }
                        catch (Exception ex)
                        {
                            var Exception = ex;
                            transaction.Rollback();
                            //return "Not Inserted!";
                            message = "3";
                            return message;
                        }

                    }
                }
                else
                {
                    message = "4";
                    //return "Code already exist";
                    return message;
                }
            }

        }
        public async Task<GetPagedAgencyModel> GetPagedAgency(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedAgencyModel();
                var productDenoList = new List<OrganizationModel>();

                if (model.AuthAllowed == true)
                {
                    var list = await _dbContext.Organization.Where(x => x.IsDeleted == false && x.IsActive == true &&
                                  (x.Name.ToLower().Contains(model.Keyword.ToLower()) 
                                )).OrderByDescending(x => x.Id).ToListAsync();
                    productDenoList = _mapper.Map<List<OrganizationModel>>(list);
                    // return list;
                }


                else
                {
                    var list = await _dbContext.Organization.Where(x => x.IsDeleted == false && x.IsActive == true &&
                                (x.Name.ToLower().Contains(model.Keyword.ToLower())
                              )).OrderByDescending(x => x.Id).ToListAsync();
                    productDenoList = _mapper.Map<List<OrganizationModel>>(list);
                    // return list;
                }
                //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

                result.OrganizationModel = GetPage(productDenoList, model.Page, model.PageSize);
                result.TotalCount = productDenoList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AgencyDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Organization Organizationdb = _dbContext.Organization.Where(u => u.Id == id).FirstOrDefault();
               List<SecUser> DbUser = await Task.Run(() => _dbContext.SecUser.Where(x => x.OrganizationId==id && x.IsDeleted == false).ToList());
                List<SecUser> deleteusers = new List<SecUser>();
                if (Organizationdb != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        Organizationdb.IsDeleted = true;
                        await base.UpdateAsync(Organizationdb);
                        await _unitOfWork.SaveChangesAsync();
                        SecUser secusers = new SecUser();
                       
                        foreach (var users in DbUser)
                        {
                            secusers = users;
                              secusers.IsDeleted = true;

                           // deleteusers.Add(secusers);
                            _dbContext.SecUser.Update(secusers);
                            await _unitOfWork.SaveChangesAsync();



                        }

                       // await _unitOfWork.SaveChangesAsync();



                        transaction.Commit();


                        return "Successfully Deleted!";

                    }
                    catch (Exception ex)
                    {
                        var Exception = ex;
                        transaction.Rollback();
                        return "Not Deleted!";
                    }
                }
                else
                {
                    return "User not Exists!";
                }


            }
            // return "User Already Exists!";
        }
    }
}
