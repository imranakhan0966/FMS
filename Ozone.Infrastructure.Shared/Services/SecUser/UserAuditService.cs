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
   public class UserAuditService : GenericRepositoryAsync<UserAudit>, IUserAuditService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public UserAuditService(
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
        public async Task<string> Create(UserAuditModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserAudit DbResult = await Task.Run(() => _dbContext.UserAudit.Where(x => x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    //long newid;
                    bool New = false;
                    if (DbResult == null)
                    {
                        New = true;
                        DbResult = new UserAudit();
                    }
                    DbResult.UserId = input.UserId;
                    DbResult.Organization = input.Organization;
                    DbResult.StandardId = input.StandardId;
                    DbResult.EacodeId = input.EacodeId;
                    DbResult.NaceCodeId = input.NaceCodeId;
                    DbResult.AuditLevel = input.AuditLevel;
                    DbResult.AuditTypeId = input.AuditTypeId;
                    DbResult.Duration = input.Duration;
                    DbResult.Year = input.Year;
                    DbResult.CertificationBodyId = input.CertificationBodyId;


                    if (New == true)
                    {
                        DbResult.CreatedBy = input.CreatedBy;
                        DbResult.CreatedDate = input.CreatedDate;
                        DbResult.IsDeleted = false;
                        await base.AddAsync(DbResult);
                        message = "Successfully Inserted!";
                    }
                    else
                    {
                        
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

        public async Task<UserAuditModel> GetUserAuditBYId(long id)
        {
            var result = new UserAuditModel();
            var Dbresult = await Task.Run(() => _dbContext.UserAudit.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<UserAuditModel>(Dbresult);
            return result;
        }

        private List<UserAuditModel> GetPage(List<UserAuditModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedUserAuditModel> GetPagedUserAuditResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedUserAuditModel();
                var UserStdList = new List<UserAuditModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();

                var list = await _dbContext.UserAudit.Include(x=>x.Standard).Include(x=>x.NaceCode).Include(x=>x.Eacode).Include(x=>x.AuditType).Include(x=>x.CertificationBody).Where(x => x.IsDeleted == false && x.UserId.ToString() == model.Keyword).ToListAsync();
                UserStdList = _mapper.Map<List<UserAuditModel>>(list);
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

                result.UserAuditModel = GetPage(UserStdList, model.Page, model.PageSize);
                result.TotalCount = UserStdList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> UserAuditDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                UserAudit dbresult = _dbContext.UserAudit.Where(u => u.Id == id).FirstOrDefault();


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
                        var Exception = ex;
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
     

    }
}

