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
    public class TenantFlatService : GenericRepositoryAsync<Flats>, ITenantFlatService
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

        public TenantFlatService(
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
        /// Gets All Flat
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Flat
        /// </returns>
        public async Task<List<FlatModel>> GetAllFlats(AdvanceQueryParameter queryParameter)
        {
            var result = new List<FlatModel>();

            var query = _dbContext.Flats.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => x);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);
            if (sieveModel.Filters != null)
            {
                var getFlatId = sieveModel.Filters.Contains("FloorId");
                if (getFlatId != false)
                {
                    string isAllocated = string.Empty;
                    string floorId = string.Empty;
                    var splitFlat = sieveModel.Filters.Split(',');
                    foreach (var filter in splitFlat)
                    {
                        var splitFilter = filter.Split("==");
                        if (splitFilter[0].Contains("FloorId"))
                        {
                            floorId = splitFilter[1];
                        }
                        if (splitFilter[0].Contains("IsAllotted"))
                        {
                            isAllocated = splitFilter[1];
                        }
                    }
                    var list = await Task.Run(() => query.Where(x => x.FloorId == Convert.ToInt32(floorId) && x.IsAllotted == Convert.ToBoolean(isAllocated)).ToList());
                    result = _mapper.Map<List<FlatModel>>(list);
                }
                else
                {
                    var list = await Task.Run(() => query.ToList());
                    result = _mapper.Map<List<FlatModel>>(list);
                }
            }
            else
            {
                var list = await Task.Run(() => query.ToList());
                result = _mapper.Map<List<FlatModel>>(list);
            }
            return result;
        }

        /// <summary>
        /// Gets All Flat
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Flat
        /// </returns>
        public async Task<List<FlatModel>> GetAllFlatsByUpdate(AdvanceQueryParameter queryParameter)
        {
            var result = new List<FlatModel>();

            var query = _dbContext.Flats.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => x);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);
            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<FlatModel>>(list);
            return result;
        }

        /// <summary>
        /// Insert a Flat
        /// </summary>
        /// <param name="input">FlatModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> InsertFlat(FlatDetailModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var chkBuilding = await Task.Run(() => _dbContext.Buildings.Where(x => x.Id == input.BuildingId).FirstOrDefaultAsync());
                FlatModel flatModel = new FlatModel();
                try
                {
                    for (int i = 0; i < input.totalApartment; i++)
                    {
                        flatModel.IsDeleted = false;
                        flatModel.BuildingId = input.BuildingId;
                        flatModel.FloorId = input.FloorId;
                        if (chkBuilding != null && chkBuilding.FlatPrefix != null)
                        {
                            flatModel.Name = chkBuilding.FlatPrefix.Trim() + "/" + input.startApartment;
                        }
                        else
                        {
                            flatModel.Name = input.startApartment.ToString();
                        }
                        flatModel.IsActive = true;
                        flatModel.IsAllotted = false;
                        flatModel.ParkingSlotId = input.ParkingSlotId;
                        input.IsAllotted = false;
                        await base.AddAsync(_mapper.Map<Flats>(flatModel));
                        input.startApartment++;
                    }
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
        /// Gets a Flat
        /// </summary>
        /// <param name="FlatId">Flat identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Flat
        /// </returns>
        public async Task<FlatModel> GetFlatById(long FlatId)
        {
            var result = new FlatModel();
            var obj = await Task.Run(() => _dbContext.Flats.Where(x => x.Id == FlatId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<FlatModel>(obj);
            return result;
        }

        /// <summary>
        /// Update a FLat
        /// </summary>
        /// <param name="flatId">Flat Identifier</param>
        /// <param name="input">FlatModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateFlat(long flatId, FlatModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Flats flat = await Task.Run(() => _dbContext.Flats.Where(x => x.Id == flatId).FirstOrDefault());
                if (flat == null) return "Service Request Not Found!";

                try
                {
                    if (!String.IsNullOrEmpty(input.Name)) flat.Name = input.Name;
                    if (!String.IsNullOrEmpty(input.Code)) flat.Code = input.Code;
                    if (input.FloorId > 0) flat.FloorId = input.FloorId;
                    if (input.ParkingSlotId > 0) flat.ParkingSlotId = input.ParkingSlotId;
                    if (input.IsAllotted != null) flat.IsAllotted = input.IsAllotted;
                    if (input.ParkingSlotId == null) flat.ParkingSlotId = input.ParkingSlotId;

                    if (!String.IsNullOrEmpty(flat.Code)) flat.Code = flat.Id.ToString();

                    await base.UpdateAsync(_mapper.Map<Flats>(flat));
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
