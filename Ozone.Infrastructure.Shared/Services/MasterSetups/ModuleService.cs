using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
  public  class ModuleService : GenericRepositoryAsync<Module>, IModuleService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public ModuleService(
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
        public async Task<string> Create(ModuleModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Module DbModules = await Task.Run(() => _dbContext.Module.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbModules == null)
                    {
                        New = true;
                        DbModules = new Module();
                    }
                    //DbModules.Id = input.Id;
                    DbModules.Name = input.Name;
                    DbModules.IsActive = input.IsActive;
                    DbModules.Description = input.Description;
                   
                    DbModules.Code = input.Code;

                    if (New == true)
                    {
                        DbModules.IsDeleted = false;
                        await base.AddAsync(DbModules);
                    }
                    else
                    {
                        await base.UpdateAsync(DbModules);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbModules.Id;

                    transaction.Commit();
                    return "Successfully Inserted!";

                }

                catch
                {
                    transaction.Rollback();
                    return "Not Inserted!";
                }



            }

        }

        public async Task<ModuleModel> GetModuleBYId(long id)
        {
            var result = new ModuleModel();
            var DbModule = await Task.Run(() => _dbContext.Module.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<ModuleModel>(DbModule);
            return result;
        }

        private List<ModuleModel> GetPage(List<ModuleModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedModuleModel> GetPagedModuleResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedModuleModel();
                var productDenoList = new List<ModuleModel>();

                //if (model.AuthAllowed == true)
                //{
                    //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                    //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                    //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                    //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                    // return list;

                    var list = await Task.Run(() => _dbContext.Module.Where(x => x.IsDeleted == false).ToList());
                    productDenoList = _mapper.Map<List<ModuleModel>>(list);
                //}


                //else
                //{
                //    var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //                 (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //                x.Code.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //    productDenoList = _mapper.Map<List<ModulesModel>>(list);
                //    // return list;
                //}
                //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

                result.ModuleModel = GetPage(productDenoList, model.Page, model.PageSize);
                result.TotalCount = productDenoList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> ModuleDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Module dbresult = _dbContext.Module.Where(u => u.Id == id).FirstOrDefault();


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
    }
}
    
