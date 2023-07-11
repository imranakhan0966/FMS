using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;

using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Parameters;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{

    public class CountryService : GenericRepositoryAsync<Countries>, ICountryService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SieveProcessor _sieveProcessor;

        public CountryService(
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

        public async Task<string> Create(CountryModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Countries DbCountry = await Task.Run(() => _dbContext.Countries.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbCountry == null)
                    {
                        New = true;
                        DbCountry = new Countries();
                    }
                    //DbModules.Id = input.Id;
                    DbCountry.Id = input.Id;
                    DbCountry.Name = input.Name;
                    DbCountry.IsActive = input.IsActive;
                    DbCountry.Code = input.Code;





                    if (New == true)
                    {
                        DbCountry.IsDeleted = false;
                        await base.AddAsync(DbCountry);
                    }
                    else
                    {
                        await base.UpdateAsync(DbCountry);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbCountry.Id;

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

        public async Task<List<CountryModel>> GetAllCounties(AdvanceQueryParameter queryParameter)
        {
            var result = new List<CountryModel>();

            var query = _dbContext.Countries.Where(x => x.IsActive == true);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);

            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<CountryModel>>(list);
            return result;
        }

        public async Task<string> CountryDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Countries DbCountry = _dbContext.Countries.Where(u => u.Id == id).FirstOrDefault();


                if (DbCountry != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbCountry.IsDeleted = true;
                        await base.UpdateAsync(DbCountry);
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

        public async Task<CountryModel> GetCountryBYId(long id)
        {
            var result = new CountryModel();
            var DbCountry = await Task.Run(() => _dbContext.Countries.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<CountryModel>(DbCountry);
            return result;
        }

        private List<CountryModel> GetPage(List<CountryModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedCountryModel> GetPagedCountryResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedCountryModel();
                var productDenoList = new List<CountryModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.Countries.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<CountryModel>>(list);
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

                result.CountryModel = GetPage(productDenoList, model.Page, model.PageSize);
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

