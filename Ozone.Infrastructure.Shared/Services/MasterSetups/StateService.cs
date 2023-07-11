using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;

using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using Ozone.Application.Parameters;
using Sieve.Models;

namespace Ozone.Infrastructure.Shared.Services
{
   public class StateService : GenericRepositoryAsync<State>, IStateService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SieveProcessor _sieveProcessor;
        public StateService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        SieveProcessor sieveProcessor,
        IUserSessionHelper userSession) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._sieveProcessor = sieveProcessor;
            this._userSession = userSession;
            //_mockData = mockData;
        }

        public async Task<List<StateModel>> GetAllStates(AdvanceQueryParameter queryParameter)
        {
            var result = new List<StateModel>();

            var query = _dbContext.State.Where(x => x.IsActive == true);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);

            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<StateModel>>(list);
            return result;
        }

        public async Task<string> Create(StateModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                State DbState = await Task.Run(() => _dbContext.State.Where(x =>x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbState == null)
                    {
                        New = true;
                        DbState = new State();
                    }
                    //DbModules.Id = input.Id;
                    DbState.Id = input.Id;
                    DbState.Name = input.Name;
                    DbState.IsActive = input.IsActive;
                    DbState.Code = input.Code;
                    DbState.CountryId = input.CountryId;
                    





                    if (New == true)
                    {
                        DbState.IsDeleted = false;
                        await base.AddAsync(DbState);
                    }
                    else
                    {
                        await base.UpdateAsync(DbState);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbState.Id;

                    transaction.Commit();
                    return "Successfully Saved!";

                }

                catch
                {
                    transaction.Rollback();
                    return "Not Inserted!";
                }



            }

        }

        public async Task<string> StateDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                State DbState = _dbContext.State.Where(u => u.Id == id).FirstOrDefault();


                if (DbState != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbState.IsDeleted = true;
                        await base.UpdateAsync(DbState);
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
        public async Task<StateModel> GetStateBYId(long id)
        {
            var result = new StateModel();
            var DbState = await Task.Run(() => _dbContext.State.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<StateModel>(DbState);
            return result;
        }

        private List<StateModel> GetPage(List<StateModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedStateModel> GetPagedStateResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedStateModel();
                var productDenoList = new List<StateModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.State.Include(x=>x.Country).Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<StateModel>>(list);
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

                result.StateModel = GetPage(productDenoList, model.Page, model.PageSize);
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
