using System.Runtime.CompilerServices;
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
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Sieve.Services;
using Sieve.Models;

namespace Ozone.Infrastructure.Shared.Services
{
    public class TenantBuildingService : GenericRepositoryAsync<Buildings>, ITenantBuildingService
    {
        #region Fields
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;

        private readonly SieveProcessor _sieveProcessor;

        #endregion

        #region Ctor

        public TenantBuildingService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
         // IUserSessionHelper userSession,
         SieveProcessor sieveProcessor,
         IConfiguration configuration) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._sieveProcessor = sieveProcessor;
            //_mockData = mockData;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets All Building
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of building
        /// </returns>
        public async Task<List<BuildingsModel>> GetAllBuildings(AdvanceQueryParameter queryParameter)
        {
            var result = new List<BuildingsModel>();
            var query = await Task.Run(() => _dbContext.Buildings.Include(x => x.Country).Include(x => x.State).Include(x => x.City).Include(x => x.Client).Where(x => x.IsActive == true && x.IsDeleted == false));

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);

            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<BuildingsModel>>(list);
            return result;
        }

        /// <summary>
        /// Gets a Building
        /// </summary>
        /// <param name="BuildingId">Building identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Building
        /// </returns>
        public async Task<BuildingsModel> GetBuildingById(long BuildingId)
        {
            var result = new BuildingsModel();
            var obj = await Task.Run(() => _dbContext.Buildings.Where(x => x.Id == BuildingId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<BuildingsModel>(obj);
            return result;
        }

        /// <summary>
        /// Insert a Building
        /// </summary>
        /// <param name="input">BuildingsModel object</param>
        /// <returns>A task that represents the asynchronous operation</re~turns>
        public async Task<string> InsertBuilding(BuildingsModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    await base.AddAsync(_mapper.Map<Buildings>(input));
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
        }

        /// <summary>
        /// Update a Building
        /// </summary>
        /// <param name="buildingId">Building Identifier</param>
        /// <param name="input">ServiceRequest object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateBuilding(long buildingId, BuildingsModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Buildings building = await Task.Run(() => _dbContext.Buildings.Where(x => x.Id == buildingId).FirstOrDefault());
                if (building == null) return "Service Request Not Found!";

                try
                {
                    if (!String.IsNullOrEmpty(input.Name)) building.Name = input.Name;
                    if (input.Code > 0) building.Code = input.Code;
                    if (input.CountryId > 0) building.CountryId = input.CountryId;
                    if (input.StateId > 0) building.StateId = input.StateId;
                    if (input.CityId > 0) building.CityId = input.CityId;
                    if (input.ClientId > 0) building.ClientId = input.ClientId;

                    if (building.Code > 0) building.Code = (int) building.Id;

                    await base.UpdateAsync(_mapper.Map<Buildings>(building));
                    await _unitOfWork.SaveChangesAsync();
                    transaction.Commit();
                    return "Successfully Updated!";
                }
                catch (Exception ex)
                {
                    var Exception = ex;
                    transaction.Rollback();
                    return "Not Updated!";
                }
            }
        }

        #endregion
    }
}
