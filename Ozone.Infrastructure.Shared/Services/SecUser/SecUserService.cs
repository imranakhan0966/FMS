using AutoMapper;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
//using Ozone.Application.Interfaces.Security;
using Ozone.Application.Parameters;
using System;
//using Ozone.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozone.Application.Helpers;
using Ozone.Application.Interfaces.Service;
using Ozone.Application;
using Ozone.Infrastructure.Persistence.Models;
using Ozone.Application.Interfaces.Security;
//using System.Data.Entity;
//using Ozone.Infrastructure.Persistence.Repository;
using Ozone.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Ozone.Infrastructure.Persistence;
using Ozone.Application.Repository;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

//using AutoMapper


namespace Ozone.Infrastructure.Shared.Services
{
    public class SecUserService : GenericRepositoryAsync<SecUser>, ISecUserService
    {
        //ISecPolicyService _secPolicyRepo;
       // ISecUserRepositoryAsync _secuserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        //private readonly OzoneContext _context;
       // private IDataShapeHelper<SecUser> _dataShaper;
        private readonly OzoneContext _dbContext;
        IConfiguration _configuration;
        public SecUserService(/*ISecPolicyService secPolicyRepo,*/
           //ISecUserRepositoryAsync secuserRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           IUserSessionHelper userSession,
           OzoneContext dbContext,
            IConfiguration configuration


            ) : base(dbContext)
        {
            //this._secPolicyRepo = secPolicyRepo;
           // this._secuserRepository = secuserRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userSession = userSession;
            _dbContext = dbContext;
            this._configuration = configuration;

        }
        public async Task<GetPagedUserRemarksModel> GetPagedUserRemarks(PagedResponseModel model)
        {
            try
            {
                // OzoneContext _dbContext = new OzoneContext();
                var result = new GetPagedUserRemarksModel();
                var userList = new List<UserRemarksModel>();

                //var list = string.Empty;
                if (model.AuthAllowed == true)
                {
                    var list = await _dbContext.UserRemarks.Include(x => x.ApprovalStatus).Include(x=>x.RemarksBy).Where(x => x.IsDeleted == false && x.UserId.ToString()==model.Keyword)
                                  .OrderByDescending(x => x.Id).ToListAsync();
                    userList = _mapper.Map<List<UserRemarksModel>>(list);
                  
                }
               


               
                result.UserRemarksModel = GetPage(userList, model.Page, model.PageSize);
                result.TotalCount = userList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<UserRemarksModel> GetPage(List<UserRemarksModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<SecUserPagedModel> GetPagedSecUserReponse(long id,PagedResponseModel model)
        {
            try
            {
               // OzoneContext _dbContext = new OzoneContext();
                var result = new SecUserPagedModel();
                var userList = new List<SecUserModel>();

                //var list = string.Empty;
                //if (model.AuthAllowed == true)
                //{
                    var list = await _dbContext.SecUser.Include(x => x.Organization).Include(x=>x.Department).Include(x=>x.Role).Include(x=>x.ApprovelStatus).Where(x => x.IsClosed == false && x.IsDeleted == false && x.OrganizationId==id &&
                                 (x.Department.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                                x.UserName.ToLower().Contains(model.Keyword.ToLower()) || x.FullName.ToLower().Contains(model.Keyword.ToLower()) || x.Role.Name.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                    userList = _mapper.Map<List<SecUserModel>>(list);
                    //userList = (from d in _dbContext.SecUser
                    //            join c in _dbContext.Department on d.DepartmentId equals c.Id
                    //            join s in _dbContext.SecRole on d.RoleId equals s.Id
                    //            join u in _dbContext.UserType on d.UserTypeId equals u.Id
                    //            where (d.IsSubmitted == true && d.IsClosed == false && d.IsActive == true && d.UserName.ToLower().Contains(model.Keyword.ToLower()) || d.FullName.ToLower().Contains(model.Keyword.ToLower()))
                    //            select new SecUserModel
                    //            {
                    //                Id = d.Id,
                    //                UserName = d.UserName,
                    //                FullName = d.FullName,
                    //                Email = d.Email,
                    //                RoleName = s.Name,
                    //                DepartmentName = c.Name,
                    //                RoleId = d.RoleId,
                    //                DepartmentId = d.DepartmentId,
                    //                Password = d.Password,
                    //                UserTypeId = d.UserTypeId,
                    //                UserTypeName = u.Name,


                    //            }).ToList();
                    // var test = _dbContext.SecUser.Where(x => x.IsSubmitted == true && x.IsClosed == false && x.IsActive == true).ToList();
                    //    var list = _dbContext.SecUser.Where(x => x.IsSubmitted == true && x.IsClosed == false && x.IsActive == true &&
                    //              (x.Department.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                    //             x.UserName.ToLower().Contains(model.Keyword.ToLower()) || x.FullName.ToLower().Contains(model.Keyword.ToLower()) || x.Role.Name.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                    //// userList = _mapper.Map<List<SecUserModel>>(li);
                    //var list = _dbContext.SecUser.Include(x => x.Department).Include(x => x.Role).Where(x => x.IsSubmitted == true && x.IsClosed == false && x.IsActive == true &&
                    //              (x.Department.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                    //             x.UserName.ToLower().Contains(model.Keyword.ToLower()) || x.FullName.ToLower().Contains(model.Keyword.ToLower()) || x.Role.Name.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                    //userList = _mapper.Map<List<SecUserModel>>(list);
                //}
                //else
                //{
                //    var list = await _dbContext.SecUser.Include(x => x.Department).Include(x => x.Role).Where(x =>x.IsDeleted == false && x.IsClosed == false && x.IsActive == true &&
                //                 (x.Department.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //                x.UserName.ToLower().Contains(model.Keyword.ToLower()) || x.FullName.ToLower().Contains(model.Keyword.ToLower()) || x.Role.Name.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //    userList = _mapper.Map<List<SecUserModel>>(list);
                //}



                // var list = await _secuserRepository.GetPagedSecUserReponseAsync(model);
               // userList = _mapper.Map<List<SecUserModel>>(list);
                result.SecUserModel = GetPage(userList, model.Page, model.PageSize);
                result.TotalCount = userList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<SecUserModel> GetAllLocationsByUserId(long id)
        //{
        //    try
        //    {
        //        var result = new SecUserModel();
        //        var userlocList = await _secuserRepository.GetUsersById(id);
        //        //var list = await _secRoleFormRepository.GetAllPermissions(id);
        //        result = _mapper.Map<SecUserModel>(userlocList);
        //        return result;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        private List<SecUserModel> GetPage(List<SecUserModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<string> SubmitForReview(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                SecUser user = _dbContext.SecUser.Where(u => u.Id == id).FirstOrDefault();

                if(user!=null)
                {
                    user.ApprovelStatusId = 1;
                    await base.UpdateAsync(user);
                    await _unitOfWork.SaveChangesAsync();
                   
                    transaction.Commit();
                    return "Successfully Record Send For Review !";
                }
                else
                {
                    return "User Not Exists!";
                }
            }

        }
        public async Task<string> CreateUser(SecUserModel input)
        {
           // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                SecUser user = _dbContext.SecUser.Where(u => u.UserName == input.UserName).FirstOrDefault();

               // if (user != null)
                   // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);
                if (user == null)
                {
                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                    if (input.ConfirmPassword == input.Password)
                    {

                        try
                        {
                            SecUser secuserEntity = new SecUser();
                            secuserEntity.Password = input.Password;
                            secuserEntity.UserName = input.UserName;
                            secuserEntity.FullName = input.FullName;
                            secuserEntity.DepartmentId = input.DepartmentId;
                            secuserEntity.IsActive = input.IsActive;
                            secuserEntity.RoleId = input.RoleId;
                            secuserEntity.IsClosed = false ;
                            secuserEntity.Email = input.Email;
                            secuserEntity.UserTypeId = input.UserTypeId;
                            secuserEntity.OrganizationId = input.OrganizationId;
                            secuserEntity.ParentUserId = input.ParentUserId;

                            secuserEntity.FirstName = input.FirstName;
                            secuserEntity.EmailForgotPassword = input.EmailForgotPassword;

                            secuserEntity.Designation = input.Designation;




                            // var secuserEntity = _mapper.Map<SecUser>(input);
                            HashingHelper hashHelper = HashingHelper.GetInstance();
                            string securityKey = string.Empty;
                            string pwdHash = hashHelper.GenerateHash(secuserEntity.Password, ref securityKey);
                            secuserEntity.Password = pwdHash;
                            secuserEntity.SecurityKey = securityKey;
                           // secuserEntity.BaseLocationId = input.BaseLocationId;
                            secuserEntity.ProfileExpiryDate = null;
                            secuserEntity.AccessFailedCount = 0;
                            secuserEntity.LockedDateTime = null;
                            secuserEntity.CreatedBy =1;
                            secuserEntity.CreatedDate = DateTime.Now;
                            secuserEntity.PwdChangeDateTime = null;
                            secuserEntity.ProfileExpiryDate = null;
                            secuserEntity.RetirementDate = null;
                            secuserEntity.IsSubmitted = input.IsSubmitted;

                            await base.AddAsync(secuserEntity);
                            //await base.AddAsync(secuserEntity);
                            //await SecUser.(secuserEntity);
                           // _dbContext.SecUser.Add(secuserEntity);
                            //  ozonedb.Add
                            //  await _secuserRepository.CreateUser(secuserEntity);
                            // await _unitOfWork.SaveChangesAsync();
                            await _unitOfWork.SaveChangesAsync();
                            transaction.Commit();
                            return "Successfully Inserted!";

                        }
                        catch (Exception ex)
                        {
                            var Exception = ex;
                            transaction.Rollback();
                            return "Not Inserted!";
                        }

                    }
                    else
                    {
                        return "Password doesn't match Confirm Password";
                    }
                }
                else
                {
                    return "User Already Exists!";
                }
            }

        }
        public async Task<string> CreateUserWithFiles(UserDataWithFilesModel input)
        {
            EmailSending emailSending = new EmailSending(_configuration);
            var response = emailSending.EmailRequest(input.Email, "Congratulations!" + "\n" + "Mr/Miss: " + input.FullName + " " + input.FirstName, "Your Account is Generated on Activo-FMS", "Your UserName: " + input.Email + " and your Password:" + input.Password + "\n" + "Thanks Best Regards" + "\n" + "Activo-FMS");
            if (!response.Contains("successfully Send"))
            {
                return null;
            }
            if (input.createdByUser == false)
            {
                var chkBuildManager = await Task.Run(() => _dbContext.SecUser.Where(x => x.BuildingId == input.BuildingId && x.RoleId == 23).ToList());
                if(chkBuildManager.Count > 0)
                {
                    foreach (var item in chkBuildManager)
                    {
                        var getRes = emailSending.EmailRequest(item.Email, "Congratulations!" + "\n" + "Mr/Miss: " + input.FullName + " " + input.FirstName, "Your Account is Generated on Activo-FMS", "Your UserName: " + input.Email + " and your Password:" + input.Password + "\n" + "Thanks Best Regards" + "\n" + "Activo-FMS");
                        if (!getRes.Contains("successfully Send"))
                        {
                            return null;
                        }
                    }
                }
                
            }
          
            var message = "";
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var loginuser=_dbContext.SecUser.Where(u => u.Id == input.CreatedBy).FirstOrDefault();

              var usercount = _dbContext.SecUser.Where(u => u.RoleId ==6 &&  u.OrganizationId== input.OrganizationId && u.IsDeleted==false && u.IsActive==true).FirstOrDefault();
                             
                SecUser userdb = null;
                SecUser sec_user = _dbContext.SecUser.Where(u => u.UserName == input.Email && u.IsDeleted == false).FirstOrDefault();
                if (input.Id > 0)
                {
                    userdb = _dbContext.SecUser.Where(u => u.Id == input.Id && u.IsDeleted==false).FirstOrDefault();


                }
                // if (user != null)
                // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);
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
                        message= "1";
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

                            if (usercount!=null && usercount.RoleId == input.RoleId)
                            {
                                message = "5";
                                return message;
                            }
                            }
                            // SecUser secuserEntity = new SecUser();
                          
                            userdb.UserName = input.Email;
                            userdb.FullName = input.FullName;
                            //userdb.DepartmentId = input.DepartmentId;
                            userdb.IsActive = input.IsActive;
                            userdb.RoleId = 22;
                        userdb.FirstName = input.FirstName;
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


                        // secuserEntity.Designation = input.Designation;

                        if (New == true)
                              {
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
                            
                            await base.AddAsync(userdb);
                            // message = "Successfully Inserted!";
                            message = "2";
                            }
                            else
                            {
                                await base.UpdateAsync(userdb);
                            //Message = "Successfully Updated!";
                            message = "3";
                            }

                            await _unitOfWork.SaveChangesAsync();
                            newid = userdb.Id;
                          

                            if (input.PhotoFile != null || input.ConfidentialityFile != null || input.ContractFile != null)
                            {
                                if (input.PhotoFile != null)
                                {
                                    string filename = Path.GetFileName(input.PhotoFile.FileName);
                                    string ContentType = input.PhotoFile.ContentType;

                                    string reportPath = _configuration["Reporting:UserphotoPath"];

                                    // string newFileName = @"D:\Update work\LIbrary_Documents\" + +newid + "_" + filename;

                                    string newFileName = reportPath + +newid + "_" + filename;
                                    // string newFileName = @"G:\OzoneDocuments\LibraryDocument\" + +newid + "_" + filename;
                                    using (var stream = new FileStream(newFileName, FileMode.Create))
                                    {
                                        await input.PhotoFile.CopyToAsync(stream);

                                    }
                                    userdb.PhotoPath = newFileName;
                                    userdb.PhotoContentType = ContentType;


                                }

                                if (input.ConfidentialityFile != null)
                                {
                                    string filename = Path.GetFileName(input.ConfidentialityFile.FileName);
                                    string ContentType = input.ConfidentialityFile.ContentType;

                                    string reportPath = _configuration["Reporting:UserphotoPath"];

                                    // string newFileName = @"D:\Update work\LIbrary_Documents\" + +newid + "_" + filename;

                                    string newFileName = reportPath + +newid + "_" + filename;
                                    // string newFileName = @"G:\OzoneDocuments\LibraryDocument\" + +newid + "_" + filename;
                                    using (var stream = new FileStream(newFileName, FileMode.Create))
                                    {
                                        await input.ConfidentialityFile.CopyToAsync(stream);

                                    }
                                    userdb.ConfidentialityPath = newFileName;
                                    userdb.ConfidentialityContentType = ContentType;


                                }
                                if (input.ContractFile != null)
                                {
                                    string filename = Path.GetFileName(input.ContractFile.FileName);
                                    string ContentType = input.ContractFile.ContentType;

                                    string reportPath = _configuration["Reporting:UserphotoPath"];

                                    // string newFileName = @"D:\Update work\LIbrary_Documents\" + +newid + "_" + filename;

                                    string newFileName = reportPath + +newid + "_" + filename;
                                    // string newFileName = @"G:\OzoneDocuments\LibraryDocument\" + +newid + "_" + filename;
                                    using (var stream = new FileStream(newFileName, FileMode.Create))
                                    {
                                        await input.ContractFile.CopyToAsync(stream);

                                    }
                                    userdb.ContractPath = newFileName;
                                    userdb.ContractContentType = ContentType;


                                }
                                await base.UpdateAsync(userdb);
                                var result2 = await _unitOfWork.SaveChangesAsync();
                            }
                        transaction.Commit();
                        return message;

                        }
                        catch (Exception ex)
                    {
                        var Exception = ex;
                        transaction.Rollback();
                        message="4";
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
           // return "User Already Exists!";
        }
        //public async Task<SecUserModel> GetUserDataById(long id)
        //{
        //    var result = new SecUserModel();
        //    var DbUser = await Task.Run(() => _dbContext.SecUser.Where(x => x.Id == id).FirstOrDefault());
        //    result = _mapper.Map<SecUserModel>(DbUser);
        //    return result;
        //}

        //public async Task<SecUserModel> GetUserDataById(long id)
        //{
        //    var result = new SecUserModel();
        //    var DbUser = await Task.Run(() => _dbContext.SecUser.Include(x=>x.Country).Include(x => x.City).Include(x => x.State).Include(x => x.Role).Include(x => x.Prefix).Include(x => x.Department).Where(x => x.Id == id).FirstOrDefault());
        //    result = _mapper.Map<SecUserModel>(DbUser);
        //    return result;
        //}
        public async Task<SecUserModel> GetUserDataById(long id)
        {
            try
            {
                var result = new SecUserModel();
                var DbUser = await Task.Run(() => _dbContext.SecUser.Include(x => x.Country).Include(x => x.City).Include(x => x.State).Include(x => x.Role).Include(x => x.Prefix).Include(x => x.Department).Include(x=>x.ApprovelStatus).Where(x => x.Id == id).FirstOrDefault());
                result = _mapper.Map<SecUserModel>(DbUser);
                var list = await _dbContext.UserStandards.Include(x => x.Standard).Include(x => x.ApprovalStatus).Include(x => x.AuditorType).Include(x => x.CourseType).Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserStandardModel = _mapper.Map<List<UserStandardModel>>(list);
                var declarationsList = await _dbContext.UserDeclaration.Include(x => x.ContractType).Include(x => x.ApprovalStatus).Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserDeclarationModel = _mapper.Map<List<UserDeclarationModel>>(declarationsList);
                var UserAcademicList = await _dbContext.UserAcademic.Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserAcademicModel = _mapper.Map<List<UserAcademicModel>>(UserAcademicList);
                result.UserAcademicModel = _mapper.Map<List<UserAcademicModel>>(UserAcademicList);
                var UserEmploymentList = await _dbContext.UserEmployment.Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserEmploymentModel = _mapper.Map<List<UserEmploymentModel>>(UserEmploymentList);
                var UserCPDList = await _dbContext.UserCpd.Include(x => x.Standard).Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserCPDModel = _mapper.Map<List<UserCPDModel>>(UserCPDList);
                var UserProfessionalList = await _dbContext.UserProfessional.Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserProfessionalModel = _mapper.Map<List<UserProfessionalModel>>(UserProfessionalList);
                var UserConsultancyList = await _dbContext.UserConsultancy.Include(x => x.Eacode).Include(x => x.NaceCode).Include(x => x.Standard).Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserConsultancyModel = _mapper.Map<List<UserConsultancyModel>>(UserConsultancyList);
                var UserAuditList = await _dbContext.UserAudit.Include(x=>x.Standard).Include(x=>x.NaceCode).Include(x=>x.Eacode).Include(x=>x.AuditType).Include(x=>x.CertificationBody).Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserAuditModel = _mapper.Map<List<UserAuditModel>>(UserAuditList);
                var UserAuditorNaceList = await _dbContext.UserAuditorNace.Include(x => x.Standard).Include(x => x.Eacode).Include(x => x.NaceCode).Include(x=>x.ApprovalStatus).Where(x => x.IsDeleted == false && x.UserId == id).ToListAsync();
                result.UserAuditorNaceModel = _mapper.Map<List<UserAuditorNaceModel>>(UserAuditorNaceList);


                return result;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<string> UserDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                SecUser userdb = _dbContext.SecUser.Where(u => u.Id == id).FirstOrDefault();

                if (userdb != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        userdb.IsDeleted = true;
                        await base.UpdateAsync(userdb);



                        await _unitOfWork.SaveChangesAsync();

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
        public Task<string> Update(SecUserModel input)
        {
            throw new NotImplementedException();
        }

        public Task<SecUserModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateUserPassword(SecUserPasswordModel input)
        {
            throw new NotImplementedException();
        }

        public Task AuthorizeUser(long id, string Remarks)
        {
            throw new NotImplementedException();
        }

        public Task RejectUser(long id, string Remarks)
        {
            throw new NotImplementedException();
        }

        //public Task<SecUserPagedModel> GetPagedSecUserReponse(PagedResponseModel model)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<SecUserModel> GetAllLocationsByUserId(long id)
        {
            throw new NotImplementedException();
        }

        //    public async Task<string> Update(SecUserModel input)
        //    {
        //        using (var transaction = _unitOfWork.BeginTransaction())
        //        {
        //            SecUser user = _secuserRepository.GetUserByFullName(input.UserName, input.Id);
        //            if (user == null)
        //            {
        //                try
        //                {
        //                    var userList = _secuserRepository.GetUserByUserName(input.UserName);
        //                    var secuserEntity = _mapper.Map<SecUser>(input);
        //                    secuserEntity.Password = input.Password;
        //                    secuserEntity.SecurityKey = userList.SecurityKey;
        //                    secuserEntity.BaseLocationId = input.BaseLocationId;
        //                    secuserEntity.ProfileExpiryDate = null;
        //                    secuserEntity.AccessFailedCount = 0;
        //                    secuserEntity.LockedDateTime = null;
        //                    secuserEntity.CreatedBy = userList.CreatedBy;
        //                    secuserEntity.CreatedDate = userList.CreatedDate;
        //                    secuserEntity.LastModifiedBy = _userSession.UserId;
        //                    secuserEntity.LastModifiedDate = DateTime.Now;
        //                    secuserEntity.PwdChangeDateTime = null;
        //                    secuserEntity.ProfileExpiryDate = null;
        //                    secuserEntity.RetirementDate = null;
        //                    secuserEntity.IsSubmitted = input.IsSubmitted;
        //                    secuserEntity.Remarks = null;
        //                    await _secuserRepository.Update(secuserEntity);
        //                    await _unitOfWork.SaveChangesAsync();
        //                    transaction.Commit();
        //                    return "Successfully Updated!";
        //                }
        //                catch (Exception ex)
        //                {
        //                    transaction.Rollback();
        //                    return "Not Updated!";

        //                }

        //            }
        //            else
        //            {
        //                return "User Already Exists!";
        //            }
        //        }
        //    }
        //    public async Task<SecUserModel> GetById(int id)
        //    {
        //        //if (id == 0)
        //        //    id = (int)_userSession.UserId;
        //        var result = new SecUserModel();
        //        var list = _secuserRepository.GetByIdAsync(id);
        //        result = _mapper.Map<SecUserModel>(list);
        //        return result;
        //    }

        //    public async Task<string> CreateUserPassword(SecUserPasswordModel input)
        //    {
        //        using (var transaction = _unitOfWork.BeginTransaction())
        //        {
        //            SecUser user = _secuserRepository.GetByIdAsync(input.id);
        //            HashingHelper hashHelper = HashingHelper.GetInstance();

        //            string pwdHash = hashHelper.ComputeHash(input.Password, user.SecurityKey);

        //            if (pwdHash != user.Password)
        //                return "Invalid Old Password";
        //            //if (input.OldPassword == )
        //            //{
        //            //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
        //            if (input.ConfirmPassword == input.NewPassword)
        //            {

        //                try
        //                {
        //                    var secuserEntity = _mapper.Map<SecUser>(input);
        //                    var Password = input.NewPassword;
        //                    // HashingHelper hashHelper = HashingHelper.GetInstance();
        //                    string securityKey = string.Empty;
        //                    string pwdHash1 = hashHelper.GenerateHash(Password, ref securityKey);
        //                    secuserEntity.Password = pwdHash1;
        //                    secuserEntity.SecurityKey = securityKey;
        //                    secuserEntity.UserName = user.UserName;
        //                    secuserEntity.FullName = user.FullName;
        //                    secuserEntity.Email = user.Email;
        //                    secuserEntity.BaseLocationId = user.BaseLocationId;
        //                    secuserEntity.RoleId = user.RoleId;
        //                    secuserEntity.DepartmentId = user.DepartmentId;
        //                    secuserEntity.Designation = user.Designation;
        //                    secuserEntity.IsActive = user.IsActive;
        //                    secuserEntity.ProfileExpiryDate = null;
        //                    secuserEntity.AccessFailedCount = user.AccessFailedCount;
        //                    secuserEntity.LockedDateTime = null;
        //                    secuserEntity.PwdChangeDateTime = DateTime.Now;
        //                    secuserEntity.ProfileExpiryDate = null;
        //                    secuserEntity.RetirementDate = null;
        //                    secuserEntity.IsSubmitted = false;
        //                    await _secuserRepository.Update(secuserEntity);
        //                    await _unitOfWork.SaveChangesAsync();
        //                    transaction.Commit();
        //                    return "Successfully Inserted!";

        //                }
        //                catch (Exception ex)
        //                {
        //                    transaction.Rollback();
        //                    return "Not Inserted!";
        //                }

        //            }
        //            else
        //            {
        //                return "Password doesn't match Confirm Password";
        //            }
        //            //}
        //            //else
        //            //{
        //            //    return "User Already Exists!";
        //            //}

        //        }




        //        //public async Task<string> DeleteUser(long Id)
        //        //{

        //        //    try
        //        //    {
        //        //        //var selectedUser = await _secuserRepository.GetByIdAsync(id);
        //        //        _secuserRepository.DeleteUser(Id);
        //        //        await _unitOfWork.SaveChangesAsync();
        //        //        return "Successfully Deleted!";
        //        //    }
        //        //    catch (Exception)
        //        //    {
        //        //        return "Not Deleted!";
        //        //    }

        //        //}
        //    }
        //    public async Task AuthorizeUser(long id, string Remarks)
        //    {
        //        using (var transaction = _unitOfWork.BeginTransaction())
        //        {
        //            try
        //            {
        //                await _secuserRepository.Authorize(id, Remarks);

        //                await _unitOfWork.SaveChangesCheckerApprovalAsync();
        //                transaction.Commit();
        //                return;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                return;

        //            }
        //        }
        //    }
        //    public async Task RejectUser(long id, string Remarks)
        //    {
        //        using (var transaction = _unitOfWork.BeginTransaction())
        //        {
        //            try
        //            {
        //                await _secuserRepository.Reject(id, Remarks);
        //                await _unitOfWork.SaveChangesCheckerApprovalAsync();
        //                transaction.Commit();
        //                return;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                return;

        //            }
        //        }
        //    }

        public async Task<string> Approval(SecUserModel input)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                SecUser user = _dbContext.SecUser.Where(u => u.Id == input.Id).FirstOrDefault();
                UserRemarks UserRemarksDb = new UserRemarks();
                if (user != null && input.ApprovelStatusId > 0 && input.Remarks != null)
                {
                    UserRemarksDb.ApprovalStatusId = input.ApprovelStatusId;
                    UserRemarksDb.Remarks = input.Remarks;
                    UserRemarksDb.RemarksById = input.AuthorizedBy;
                    UserRemarksDb.RemarksDate = DateTime.Now;
                    UserRemarksDb.UserId = input.Id;
                    UserRemarksDb.IsDeleted = false;
                    _dbContext.Add(UserRemarksDb);
                    await _unitOfWork.SaveChangesAsync();


                    // if (user != null)
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);
                  
                        //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                        try
                        {

                            user.ApprovelStatusId = input.ApprovelStatusId;
                            //secuserEntity.AuthorizedBy=input.
                            user.Remarks = input.Remarks;







                            await base.UpdateAsync(user);
                            //await base.AddAsync(secuserEntity);
                            //await SecUser.(secuserEntity);
                            // _dbContext.SecUser.Add(secuserEntity);
                            //  ozonedb.Add
                            //  await _secuserRepository.CreateUser(secuserEntity);
                            // await _unitOfWork.SaveChangesAsync();
                            await _unitOfWork.SaveChangesAsync();
                            transaction.Commit();
                            return "Successfully Inserted!";

                        }



                        catch (Exception ex)
                    {
                        var Exception = ex;
                        transaction.Rollback();
                            return "Not Inserted!";
                        }


                    
                }
                else
                {
                    return "Status And Remarks con not be Empty";
                }
            }

        }


        public async Task<SecUserModel> DownloadConfidentiallyFile(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                SecUser DbLibrary = await Task.Run(() => _dbContext.SecUser.Where(x => x.Id == id).FirstOrDefault());

                SecUserModel Li = new SecUserModel();
                if (DbLibrary != null)
                {
                    Li.ConfidentialityPath = DbLibrary.ConfidentialityPath;
                    Li.ConfidentialityContentType = DbLibrary.ConfidentialityContentType;

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                }
                return Li;
            }

        }
        public async Task<SecUserModel> DownloadContractFile(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                SecUser DbLibrary = await Task.Run(() => _dbContext.SecUser.Where(x => x.Id == id).FirstOrDefault());

                SecUserModel Li = new SecUserModel();
                if (DbLibrary != null)
                {
                    Li.ContractPath = DbLibrary.ContractPath;
                    Li.ContractContentType = DbLibrary.ContractContentType;

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                }
                return Li;
            }
        }
            public async Task<string> UCreate(ResetPasswordModel input)
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    SecUser userdb = await Task.Run(() => _dbContext.SecUser.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                    try
                    {
                        long newid;
                        bool New = false;
                        if (userdb == null)
                        {
                            New = true;
                            userdb = new SecUser();
                        }
                        //DbModules.Id = input.Id;

                        userdb.Password = input.Password;
                        HashingHelper hashHelper = HashingHelper.GetInstance();
                        string securityKey = string.Empty;
                        string pwdHash = hashHelper.GenerateHash(userdb.Password, ref securityKey);
                        userdb.Password = pwdHash;
                        userdb.SecurityKey = securityKey;

                        if (New == true)
                        {
                            userdb.IsDeleted = false;
                            await base.AddAsync(userdb);
                        }
                        else
                        {
                            await base.UpdateAsync(userdb);
                        }

                        ResetPasswordAccount dbResetPasswordAccount = new ResetPasswordAccount();
                    dbResetPasswordAccount.EmailAddress = userdb.EmailForgotPassword;
                    if (dbResetPasswordAccount.EmailAddress == null) 
                    {
                        transaction.Rollback(); 
                        return "Email address is required!";
                    }
                    dbResetPasswordAccount.Title = userdb.UserName;
                    dbResetPasswordAccount.Subject = "Reset Password";
                    dbResetPasswordAccount.IsActive = true;
                    dbResetPasswordAccount.IsDeleted = false;
                    dbResetPasswordAccount.CreatedById = input.CreatedById;
                    dbResetPasswordAccount.UserId = input.Id;
                    dbResetPasswordAccount.CreatedByDate = DateTime.Now;
                    _dbContext.ResetPasswordAccount.Add(dbResetPasswordAccount);
                      // dbResetPasswordAccount.CreatedById = input.LastUpadatedById;

                        var result = await _unitOfWork.SaveChangesAsync();

                        newid = userdb.Id;

                       

                    //var senderEmail = new MailAddress("ozonepakistan2021@gmail.com", "Ozone Pakistan");
                    //var receiverEmail = new MailAddress(userdb.EmailForgotPassword, "Receiver");
                    //var password = "ozone2021";
                    //// var sub = "Call Back Test";
                    //var body = " Your password has been changed, New password is:  " + input.Password;
                    //var smtp = new SmtpClient
                    //{
                    //    Host = "smtp.gmail.com",
                    //    Port = 587,
                       
                    //    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //    UseDefaultCredentials = false,
                    //    //UseDefaultCredentials = true,

                    //    Credentials = new NetworkCredential(senderEmail.Address, password),
                    //     EnableSsl = true,
                    //};
                    //using (var mess = new MailMessage(senderEmail, receiverEmail)
                    //{
                    //    Subject = "New Password",
                    //    Body = body
                    //})
                    //{
                    //    //  smtp.UseDefaultCredentials = false;
                    //    smtp.Send(mess);
                    //}
                    transaction.Commit();
                    return "Successfully Changed Password!";

                    }

                    catch (Exception ex)
                {
                    var Exception = ex;
                    transaction.Rollback();
                        return "Password Not Reset, Please Verify Email Address";
                    }



                }

            }

        public async Task<SecUserModel> DownloadImage(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                SecUser DbLibrary = await Task.Run(() => _dbContext.SecUser.Where(x => x.Id == id).FirstOrDefault());

                SecUserModel Li = new SecUserModel();
                if (DbLibrary != null)
                {
                    Li.PhotoPath = DbLibrary.PhotoPath;
                    Li.PhotoContentType = DbLibrary.PhotoContentType;

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                }
                return Li;
            }
        }
    }
}
