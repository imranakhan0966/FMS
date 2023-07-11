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

namespace Ozone.Infrastructure.Shared.Services
{
  public  class UserAuditorNaceorNaceService : GenericRepositoryAsync<UserAuditorNace>, IUserAuditorNaceService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public UserAuditorNaceorNaceService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        IUserSessionHelper userSession) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._userSession = userSession;
            //_mockData = mockData;
        }
        public async Task<string> Create(UserAuditorNaceModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserAuditorNace DbResult = await Task.Run(() => _dbContext.UserAuditorNace.Where(x => x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if (DbResult == null)
                    {
                        New = true;
                        DbResult = new UserAuditorNace();
                    }
                    DbResult.UserId = input.UserId;
                    DbResult.StandardId = input.StandardId;
                    DbResult.ApprovalStatusId = input.ApprovalStatusId;
                    DbResult.EacodeId = input.EacodeId;
                    DbResult.NaceCodeId = input.NaceCodeId;

                 

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
                        SecUser Result = await Task.Run(() => _dbContext.SecUser.Where(x => x.Id == input.UserId).FirstOrDefault());
                        //if (Result.ApprovelStatusId == 3)
                        //{
                        DbResult.ApprovalStatusId = 10003;
                        //}
                        //DbResult.LastModifiedBy = input.LastModifiedBy;
                        //DbResult.LastModifiedDate = input.LastModifiedDate;
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

        public async Task<UserAuditorNaceModel> GetUserAuditorNaceBYId(long id)
        {
            var result = new UserAuditorNaceModel();
            var Dbresult = await Task.Run(() => _dbContext.UserAuditorNace.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<UserAuditorNaceModel>(Dbresult);
            return result;
        }

        private List<UserAuditorNaceModel> GetPage(List<UserAuditorNaceModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedUserAuditorNaceModel> GetPagedUserAuditorNaceResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedUserAuditorNaceModel();
                var UserStdList = new List<UserAuditorNaceModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();

                var list = await _dbContext.UserAuditorNace.Include(x=>x.Standard).Include(x=>x.Eacode).Include(x=>x.NaceCode).Include(x=>x.ApprovalStatus).Where(x => x.IsDeleted == false && x.UserId.ToString() == model.Keyword).ToListAsync();
                UserStdList = _mapper.Map<List<UserAuditorNaceModel>>(list);
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

                result.UserAuditorNaceModel = GetPage(UserStdList, model.Page, model.PageSize);
                result.TotalCount = UserStdList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> UserAuditorNaceDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                UserAuditorNace dbresult = _dbContext.UserAuditorNace.Where(u => u.Id == id).FirstOrDefault();


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

        public async Task<List<CertificationBodyModel>> GetAllCertificationBody()
        {
            var result = new List<CertificationBodyModel>();

            var list = await Task.Run(() => _dbContext.CertificationBody.Where(x => x.IsDeleted == false).ToList());
            result = _mapper.Map<List<CertificationBodyModel>>(list);
            return result;
        }

        public async Task<string> AuditorNaceApproval(UserAuditorNaceModel input)
        {
            // OzoneContext ozonedb = new OzoneContext();

            UserAuditorNace user = await Task.Run(() => _dbContext.UserAuditorNace.Where(x => x.Id == input.Id).FirstOrDefault());

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

                //_dbContext.UserAuditorNace.Update(user);
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

        public async Task<string> AuditorNaceSubmitForReviewStatus(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserAuditorNace user = _dbContext.UserAuditorNace.Where(u => u.Id == id).FirstOrDefault();

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


    }
}


