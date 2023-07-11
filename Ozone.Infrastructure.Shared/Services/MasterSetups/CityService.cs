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
using Sieve.Services;
using Ozone.Application.Parameters;
using Sieve.Models;

namespace Ozone.Infrastructure.Shared.Services.MasterSetups
{
   public class CityService : GenericRepositoryAsync<Cities>, ICityService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SieveProcessor _sieveProcessor;

        public CityService(
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

        public async Task<List<CityModel>> GetAllCities(AdvanceQueryParameter queryParameter)
        {
            var result = new List<CityModel>();

            var query = _dbContext.Cities.Where(x => x.IsActive == true);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);

            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<CityModel>>(list);
            return result;
        }

        public async Task<string> Create(CityModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Cities DbCity = await Task.Run(() => _dbContext.Cities.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbCity == null)
                    {
                        New = true;
                        DbCity = new Cities();
                    }
                    //DbModules.Id = input.Id;
                    DbCity.Id = input.Id;
                    DbCity.Name = input.Name;
                    DbCity.IsActive = input.IsActive;
                    DbCity.Code = input.Code;
                    DbCity.StateId = input.StateId;
                    DbCity.CountryId = input.CountryId;




                    if (New == true)
                    {
                        DbCity.IsDeleted = false;
                        await base.AddAsync(DbCity);
                    }
                    else
                    {
                        await base.UpdateAsync(DbCity);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbCity.Id;

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

        public async Task<string> CityDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Cities DbCity = _dbContext.Cities.Where(u => u.Id == id).FirstOrDefault();


                if (DbCity != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbCity.IsDeleted = true;
                        await base.UpdateAsync(DbCity);
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

        public async Task<CityModel> GetCityBYId(long id)
        {
            var result = new CityModel();
            var DbCity = await Task.Run(() => _dbContext.Cities.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<CityModel>(DbCity);
            return result;
        }

        private List<CityModel> GetPage(List<CityModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedCityModel> GetPagedCityResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedCityModel();
                var productDenoList = new List<CityModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.Cities.Include(x => x.Country).Include(x => x.State).Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<CityModel>>(list);
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

                result.CityModel = GetPage(productDenoList, model.Page, model.PageSize);
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
