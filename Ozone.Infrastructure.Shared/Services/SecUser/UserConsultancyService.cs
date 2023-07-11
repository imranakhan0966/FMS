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
   public class UserConsultancyService : GenericRepositoryAsync<UserConsultancy>, IUserConsultancyService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public UserConsultancyService(
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
        public async Task<string> Create(UserConsultancyModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserConsultancy DbResult = await Task.Run(() => _dbContext.UserConsultancy.Where(x => x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if (DbResult == null)
                    {
                        New = true;
                        DbResult = new UserConsultancy();
                    }
                    DbResult.UserId = input.UserId;
                    DbResult.Organization = input.Organization;
                    DbResult.StandardId = input.StandardId;
                    DbResult.Year = input.Year;
                    DbResult.DurationDays = input.DurationDays;

                    DbResult.EacodeId = input.EacodeId;
                    DbResult.NaceCodeId = input.NaceCodeId;


                    if (New == true)
                    {
                        DbResult.CreatedBy = input.CreatedBy;
                        DbResult.CreatedDate =DateTime.Now;
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

        public async Task<UserConsultancyModel> GetUserConsultancyBYId(long id)
        {
            var result = new UserConsultancyModel();
            var Dbresult = await Task.Run(() => _dbContext.UserConsultancy.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<UserConsultancyModel>(Dbresult);
            return result;
        }

        private List<UserConsultancyModel> GetPage(List<UserConsultancyModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedUserConsultancyModel> GetPagedUserConsultancyResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedUserConsultancyModel();
                var UserStdList = new List<UserConsultancyModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();

                var list = await _dbContext.UserConsultancy.Include(x=>x.NaceCode).Include(x=>x.Eacode).Include(x=>x.Standard).Where(x=>x.IsDeleted== false && x.UserId.ToString() == model.Keyword).ToListAsync();
                UserStdList = _mapper.Map<List<UserConsultancyModel>>(list);
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

                result.UserConsultancyModel = GetPage(UserStdList, model.Page, model.PageSize);
                result.TotalCount = UserStdList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> UserConsultancyDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                UserConsultancy dbresult = _dbContext.UserConsultancy.Where(u => u.Id == id).FirstOrDefault();


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

        public async Task<List<NaceCodeModel>> GetAllNaceCode()
        {
            var result = new List<NaceCodeModel>();

            var list = await Task.Run(() => _dbContext.NaceCode.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<NaceCodeModel>>(list);
            return result;
        }
        public async Task<List<EACodeModel>> GetAllEACode()
        {
            var result = new List<EACodeModel>();

            var list = await Task.Run(() => _dbContext.Eacode.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<EACodeModel>>(list);
            return result;
        }
       
    }
}


