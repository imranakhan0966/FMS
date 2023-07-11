using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Setup;
using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services.MasterSetups
{


    public class ApplicationTypeService : GenericRepositoryAsync<ApplicationType>, IApplicationTypeService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationTypeService(
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

        public async Task<string> Create(ApplicationTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ApplicationType DbApplicationType = await Task.Run(() => _dbContext.ApplicationType.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToStringApplicationType


                try
                {
                    long newid;
                    bool New = false;
                    if (DbApplicationType == null)
                    {
                        New = true;
                        DbApplicationType = new ApplicationType();
                    }
                    //DbModules.Id = input.Id;
                    DbApplicationType.Id = input.Id;
                    DbApplicationType.Name = input.Name;
                    DbApplicationType.IsActive = input.IsActive;
                    DbApplicationType.Description = input.Description;

                    DbApplicationType.Code = input.Code;
                    DbApplicationType.CreatedById = input.CreatedById;


                    if (New == true)
                    {
                        DbApplicationType.IsDeleted = false;
                        await base.AddAsync(DbApplicationType);
                    }
                    else
                    {
                        await base.UpdateAsync(DbApplicationType);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbApplicationType.Id;

                    transaction.Commit();
                    return "Successfully Saved!";

                }
                //catch (Exception ex)
                //{
                //    throw ex;
                //}

                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "Not Inserted!";
                }



            }

        }

        public async Task<string> ApplicationTypeDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                ApplicationType DbApplicationType = _dbContext.ApplicationType.Where(u => u.Id == id).FirstOrDefault();


                if (DbApplicationType != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbApplicationType.IsDeleted = true;
                        await base.UpdateAsync(DbApplicationType);
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

        public async Task<ApplicationTypeModel> GetApplicationTypeBYId(long id)
        {
            var result = new ApplicationTypeModel();
            var DbApplicationType = await Task.Run(() => _dbContext.ApplicationType.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<ApplicationTypeModel>(DbApplicationType);
            return result;
        }

        private List<ApplicationTypeModel> GetPage(List<ApplicationTypeModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedApplicationTypeModel> GetPagedApplicationTypeResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedApplicationTypeModel();
                var productDenoList = new List<ApplicationTypeModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.ApplicationType.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<ApplicationTypeModel>>(list);
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

                result.ApplicationTypeModel = GetPage(productDenoList, model.Page, model.PageSize);
                result.TotalCount = productDenoList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

