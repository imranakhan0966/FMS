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
    public class TenantParkingSlotService : GenericRepositoryAsync<ParkingSlots>, ITenantParkingSlotService
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

        public TenantParkingSlotService(
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
        /// Gets All Parking Slots
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Parking Slots
        /// </returns>
        public async Task<List<ParkingSlotModel>> GetAllParkingSlots(AdvanceQueryParameter queryParameter)
        {
            var result = new List<ParkingSlotModel>();

            var query = _dbContext.ParkingSlots.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => x);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);

            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<ParkingSlotModel>>(list);
            return result;
        }

        /// <summary>
        /// Insert a Parking Slot
        /// </summary>
        /// <param name="input">ParkingSlotModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> InsertParkingSlot(ParkingSlotDetailModel parkingSlotDetailModel)
        {
            var chkBuilding = await Task.Run(() => _dbContext.Buildings.Where(x => x.Id == parkingSlotDetailModel.BuildingId).FirstOrDefaultAsync());
            ParkingSlotModel input = new ParkingSlotModel();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < parkingSlotDetailModel.totalSlots; i++)
                    {
                        input.IsDeleted = false;
                        input.BuildingId = parkingSlotDetailModel.BuildingId;
                        input.FloorId = parkingSlotDetailModel.FloorId;
                        input.IsActive = true;
                        if (!string.IsNullOrEmpty(chkBuilding.ParkingPrefix))
                        {
                            input.Name = chkBuilding.ParkingPrefix.Trim() + "/" + parkingSlotDetailModel.startSlot;
                        }
                        else
                        {
                            input.Name = parkingSlotDetailModel.startSlot.ToString(); ;
                        }
                        
                        input.isAllotted = false;
                        await base.AddAsync(_mapper.Map<ParkingSlots>(input));
                        parkingSlotDetailModel.startSlot++;
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
        /// Gets a Parking Slot
        /// </summary>
        /// <param name="ParkingSlotId">ParkingSlot identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Parking Slot
        /// </returns>
        public async Task<ParkingSlotModel> GetParkingSlotById(long ParkingSlotId)
        {
            var result = new ParkingSlotModel();
            var obj = await Task.Run(() => _dbContext.ParkingSlots.Where(x => x.Id == ParkingSlotId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<ParkingSlotModel>(obj);
            return result;
        }

        /// <summary>
        /// Update a Parking Slot
        /// </summary>
        /// <param name="parkingSlotId">ParkingSlot Identifier</param>
        /// <param name="input">ParkingSlotModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateParkingSlot(long parkingSlotId, ParkingSlotModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ParkingSlots parkingSlots = await Task.Run(() => _dbContext.ParkingSlots.Where(x => x.Id == parkingSlotId).FirstOrDefault());
                if (parkingSlots == null) return "Service Request Not Found!";

                try
                {
                    if (!String.IsNullOrEmpty(input.Name)) parkingSlots.Name = input.Name;
                    if (!String.IsNullOrEmpty(input.Code)) parkingSlots.Code = input.Code;
                    if (input.FloorId > 0) parkingSlots.FloorId = input.FloorId;
                    if (input.isAllotted != null) parkingSlots.IsAllotted = input.isAllotted;

                    if (!String.IsNullOrEmpty(parkingSlots.Code)) parkingSlots.Code = parkingSlots.Id.ToString();

                    await base.UpdateAsync(_mapper.Map<ParkingSlots>(parkingSlots));
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
