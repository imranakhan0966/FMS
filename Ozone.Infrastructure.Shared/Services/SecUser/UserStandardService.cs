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

namespace Ozone.Infrastructure.Shared.Services
{
   public class UserStandardService : GenericRepositoryAsync<UserStandards>, IUserStandardService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;
        public UserStandardService(
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
            this._configuration = configuration;
            //_mockData = mockData;
        }
        //public async Task<string> Create(UserStandardModel input)
        //{
        //    using (var transaction = _unitOfWork.BeginTransaction())
        //    {
        //        UserStandards DbResult = await Task.Run(() => _dbContext.UserStandards.Where(x=>x.Id == input.Id).FirstOrDefault());

        //        //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


        //        try
        //        {
        //            var message = "";
        //            long newid;
        //            bool New = false;
        //            if (DbResult == null)
        //            {
        //                New = true;
        //                DbResult = new UserStandards();
        //            }
        //            DbResult.StandardId = input.StandardId;
        //            DbResult.AuditorTypeId = input.AuditorTypeId;
        //            DbResult.CourseTypeId = input.CourseTypeId;
        //            DbResult.CourseDate = input.CourseDate;
        //            DbResult.PreValidDate = input.PreValidDate;

        //            DbResult.ValidationDate = input.ValidationDate;
                   
        //            DbResult.Approvedby = input.Approvedby;
        //            DbResult.ApprovedDate = input.ApprovedDate;
        //            DbResult.UserId = input.UserId;
                  
                  

        //            if (New == true)
        //            {
        //                DbResult.ApprovalStatusId = 1;
        //                DbResult.CreatedBy = input.CreatedBy;
        //                DbResult.CreatedDate = input.CreatedDate;
        //                DbResult.IsDeleted = false;
        //                await base.AddAsync(DbResult);
        //                message = "Successfully Inserted!";
        //            }
        //            else
        //            {
        //                //SecUser Result = await Task.Run(() => _dbContext.SecUser.Where(x => x.Id == input.UserId).FirstOrDefault());
        //               // if (Result.ApprovelStatusId == 3)
        //                //{
        //                    DbResult.ApprovalStatusId = 10002;
        //                //}
        //                DbResult.LastModifiedBy = input.LastModifiedBy;
        //                DbResult.LastModifiedDate = input.LastModifiedDate;

        //                await base.UpdateAsync(DbResult);
        //                message = "Successfully Updated!";
        //            }
        //            //await base.AddAsync(secuserEntity);
        //            //await SecUser.(secuserEntity);
        //            // _dbContext.SecUser.Add(secuserEntity);
        //            //  ozonedb.Add
        //            //  await _secuserRepository.CreateUser(secuserEntity);
        //            // await _unitOfWork.SaveChangesAsync();
        //            var result = await _unitOfWork.SaveChangesAsync();

                  

        //            transaction.Commit();
        //            return message;

        //        }

        //        catch
        //        {
        //            transaction.Rollback();
        //            return "Not Inserted!";
        //        }



        //    }

        //}

        public async Task<UserStandardModel> GetUserStandardBYId(long id)
        {
            var result = new UserStandardModel();
            var Dbresult = await Task.Run(() => _dbContext.UserStandards.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<UserStandardModel>(Dbresult);
            return result;
        }

        private List<UserStandardModel> GetPage(List<UserStandardModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedUserStandardModel> GetPagedUserStandardResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedUserStandardModel();
                var UserStdList = new List<UserStandardModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                var list = await _dbContext.UserStandards.Include(x=>x.Standard).Include(x=>x.AuditorType).Include(x=>x.CourseType).Include(x=>x.User).Include(x=>x.ApprovalStatus).Where(x => x.IsDeleted == false && x.UserId.ToString() == model.Keyword).ToListAsync();
               // var list = await _dbContext.UserStandards.Include("Standard").Include("AuditorType").Include("CourseType").Where(x => x.IsDeleted == false && x.UserId.ToString() == model.Keyword).ToListAsync();
                UserStdList = _mapper.Map<List<UserStandardModel>>(list);
                // return list;
                //}


                //else
                //{
                //    var list = await _dbContext.Certification.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //                 (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //                x.Code.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //    productDenoList = _mapper.Map<List<StandardModel>>(list);
                //    // return list;
                //}
                //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

                result.UserStandardModel = GetPage(UserStdList, model.Page, model.PageSize);
                result.TotalCount = UserStdList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> UserStandardDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                UserStandards dbresult = _dbContext.UserStandards.Where(u => u.Id == id).FirstOrDefault();


                if (dbresult != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        dbresult.IsDeleted = true;
                        await base.UpdateAsync(dbresult);
                        await _unitOfWork.SaveChangesAsync();





                        transaction.Commit();


                        return "Successfully Deleted!";

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Not Deleted!";
                    }
                }
                else
                {
                    return "Client not Exists!";
                }


            }
            // return "User Already Exists!";
        }
        public async Task<List<AuditorTypeModel>> GetAllAuditorType(long? OrganizationId)
        {
            List<AuditorTypes> AuditorTypes =new List<AuditorTypes>();
            var result = new List<AuditorTypeModel>();
            if (OrganizationId == 1)
            {
                AuditorTypes = await Task.Run(() => _dbContext.AuditorTypes.Where(x => x.IsActive == true && x.UserLevel==1).ToList());
                AuditorTypes.AddRange(await Task.Run(() => _dbContext.AuditorTypes.Where(x => x.IsActive == true && x.UserLevel == null).ToList()));
                 result = _mapper.Map<List<AuditorTypeModel>>(AuditorTypes);

            }
           else
            {
                AuditorTypes = await Task.Run(() => _dbContext.AuditorTypes.Where(x => x.IsActive == true && x.UserLevel > 1).ToList());
                AuditorTypes.AddRange(await Task.Run(() => _dbContext.AuditorTypes.Where(x => x.IsActive == true && x.UserLevel == null).ToList()));
                result = _mapper.Map<List<AuditorTypeModel>>(AuditorTypes);

            }



            return result;
        }
        public async Task<List<CourseTypeModel>> GetAllCourseType()
        {
            var result = new List<CourseTypeModel>();

            var list = await Task.Run(() => _dbContext.CourseType.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<CourseTypeModel>>(list);
            return result;
        }
        public async Task<List<ApprovalStatusModel>> GetAllApprovalStatus()
        {
            var result = new List<ApprovalStatusModel>();

            var list = await Task.Run(() => _dbContext.ApprovalStatus.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<ApprovalStatusModel>>(list);
            return result;
        }
        public async Task<List<CertificationModel>> GetAllCertification()
        {
            var result = new List<CertificationModel>();

            var list = await Task.Run(() => _dbContext.Certification.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<CertificationModel>>(list);
            return result;
        }
        public async Task<List<CertificationBodyModel>> GetAllCertificationBody()
        {
            var result = new List<CertificationBodyModel>();

            var list = await Task.Run(() => _dbContext.CertificationBody.Where(x => x.IsDeleted == false).ToList());
            result = _mapper.Map<List<CertificationBodyModel>>(list);
            return result;
        }

        public async Task<List<AuditTypeModel>> GetAllAuditType()
        {
            var result = new List<AuditTypeModel>();

            var list = await Task.Run(() => _dbContext.AuditType.Where(x => x.IsDeleted == false).ToList());
            result = _mapper.Map<List<AuditTypeModel>>(list);
            return result;
        }
        public async Task<UserStandardModel> DownloadFile(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserStandards DbLibrary = await Task.Run(() => _dbContext.UserStandards.Where(x => x.Id == id).FirstOrDefault());

                UserStandardModel Li = new UserStandardModel();
                if (DbLibrary != null)
                {
                    Li.DocumentFilePath = DbLibrary.DocumentFilePath;
                    Li.DocumentContentType = DbLibrary.DocumentContentType;

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                }
                return Li;
            }

        }

        public async Task<string> SubmitForReviewStatus(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserStandards user = _dbContext.UserStandards.Where(u => u.Id == id).FirstOrDefault();

                if (user != null)
                {
                    user.ApprovalStatusId = 1;
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

        public async Task<string> Create(UserStandardModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserStandards DbResult = await Task.Run(() => _dbContext.UserStandards.Where(x => x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if (DbResult == null)
                    {
                        New = true;
                        DbResult = new UserStandards();
                    }
                    DbResult.ApprovalStatusId = input.ApprovalStatusId;
                    DbResult.StandardId = input.StandardId;
                    DbResult.AuditorTypeId = input.AuditorTypeId;
                    DbResult.CourseTypeId = input.CourseTypeId;
                    DbResult.CourseDate = input.CourseDate;
                    DbResult.PreValidDate = input.PreValidDate;

                    DbResult.ValidationDate = input.ValidationDate;

                    DbResult.Approvedby = input.Approvedby;
                    DbResult.ApprovedDate = input.ApprovedDate;
                    DbResult.UserId = input.UserId;



                    if (New == true)
                    {
                        DbResult.ApprovalStatusId = 10003;
                        DbResult.CreatedBy = input.CreatedBy;
                        DbResult.CreatedDate = input.CreatedDate;
                        DbResult.IsDeleted = false;
                        await base.AddAsync(DbResult);
                        message = "Successfully Inserted!";
                    }
                    else
                    {
                        //SecUser Result = await Task.Run(() => _dbContext.SecUser.Where(x => x.Id == input.UserId).FirstOrDefault());
                        // if (Result.ApprovelStatusId == 3)
                        //{
                        DbResult.ApprovalStatusId = 10003;
                        //}
                        DbResult.LastModifiedBy = input.LastModifiedBy;
                        DbResult.LastModifiedDate = input.LastModifiedDate;
                        DbResult.ApprovalStatusId = 10003;
                        await base.UpdateAsync(DbResult);
                        message = "Successfully Updated!";
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbResult.Id;
                    if (input.DocumentFile != null)
                    {
                        string filename = Path.GetFileName(input.DocumentFile.FileName);
                        string ContentType = input.DocumentFile.ContentType;

                        string reportPath = _configuration["Reporting:UserStandardsPath"];

                        // string newFileName = @"D:\Update work\LIbrary_Documents\" + +newid + "_" + filename;

                        string newFileName = reportPath + +newid + "_" + filename;
                        // string newFileName = @"G:\OzoneDocuments\LibraryDocument\" + +newid + "_" + filename;
                        using (var stream = new FileStream(newFileName, FileMode.Create))
                        {
                            await input.DocumentFile.CopyToAsync(stream);

                        }
                        DbResult.DocumentFilePath = newFileName;
                        DbResult.DocumentContentType = ContentType;
                        await base.UpdateAsync(DbResult);
                        var result2 = await _unitOfWork.SaveChangesAsync();




                    }
                    transaction.Commit();
                    return message;
                }

                catch
                {
                    transaction.Rollback();
                    return "Not Inserted!";
                }



            }

        }

        public async Task<string> StandardApproval(UserStandardModel input)
        {
            // OzoneContext ozonedb = new OzoneContext();

            UserStandards user = await Task.Run(() => _dbContext.UserStandards.Where(x => x.Id == input.Id).FirstOrDefault());

            //UserStandards users = _dbContext.UserStandards.Where(u => u.Id == input.Id).FirstOrDefault();


            try

            {
                user.ApprovalStatusId = input.ApprovalStatusId;
                user.Remarks = input.Remarks;
                //UserRemarksDb.RemarksById = input.RemarksById;
                //UserRemarksDb.RemarksDate = DateTime.Now;
                //UserRemarksDb.ProjectId = input.ProjectId;
                //UserRemarksDb.IsDeleted = false;

                //ClientProject.ApprovalStatusId = input.ApprovalStatusId;
                //ClientProject.Remarks = input.Remarks;


                //ProjectSA.Remarks = input.Remarks;
                //ProjectSA.ApprovalStatusId = input.ApprovalStatusId;

                //ClientProject.ProjectRemarksHistory.Add(UserRemarksDb);
                //ClientProject.ProjectSa8000.Add(ProjectSA);

                //secuserEntity.AuthorizedBy=input.

                await base.UpdateAsync(user);

                // _dbContext.UserStandards.Update(user);
                await _unitOfWork.SaveChangesAsync();

                //transaction.Commit();
                return "Succesfully Saved";

            }


            catch (Exception ex)
            {
                var Exception = ex;
                //transaction.Rollback();
                return "Status And Remarks con not be Empty";
            }



        }



    }
}
