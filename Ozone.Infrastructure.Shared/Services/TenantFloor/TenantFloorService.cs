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
    public class TenantFloorService : GenericRepositoryAsync<Floors>, ITenantFloorService
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

        public TenantFloorService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
         // IUserSessionHelper userSession,
         SieveProcessor sieveProcessor,
         IConfiguration configuration) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
            //_mockData = mockData;
            _configuration = configuration;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets All Floor
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Floor
        /// </returns>
        public async Task<List<FloorsModel>> GetAllFloors(AdvanceQueryParameter queryParameter)
        {
            var result = new List<FloorsModel>();

            var query = _dbContext.Floors.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => x);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };
            query = _sieveProcessor.Apply(sieveModel, query);
            //if (sieveModel.Filters != null)
            //{
            //    var buildId = sieveModel.Filters.Contains("BuildingId").ToString();
            //    if (buildId != null)
            //    {
            //        var splitBuildId = sieveModel.Filters.Split("==");
            //        var list = await Task.Run(() => query.Where(x => x.BuildingId == Convert.ToInt32(splitBuildId[1])).ToList());
            //        result = _mapper.Map<List<FloorsModel>>(list);
            //    }
            //    else
            //    {
            //        var list = await Task.Run(() => query.ToList());
            //        result = _mapper.Map<List<FloorsModel>>(list);
            //    }
            //}
            //else
            {
                var list = await Task.Run(() => query.ToList());
                result = _mapper.Map<List<FloorsModel>>(list);
            }
            return result;
        }

        /// <summary>
        /// Gets a Floor
        /// </summary>
        /// <param name="FloorId">Floor identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Floor
        /// </returns>
        public async Task<FloorsModel> GetFloorById(long FloorId)
        {
            var result = new FloorsModel();
            var obj = await Task.Run(() => _dbContext.Floors.Where(x => x.Id == FloorId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<FloorsModel>(obj);
            return result;
        }

        /// <summary>
        /// Insert a Floor
        /// </summary>
        /// <param name="input">FloorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> InsertFloor(FloorDetailModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                FloorsModel floorsModel = new FloorsModel();
                var chkBuilding = await Task.Run(() => _dbContext.Buildings.Where(x => x.Id == input.BuildingId).FirstOrDefaultAsync());
                try
                {
                    for (int i = 0; i < input.totalFloor; i++)
                    {
                        floorsModel.BuildingId = input.BuildingId;
                        floorsModel.IsDeleted = false;
                        floorsModel.FloorTypeId = input.FloorTypeId;
                        floorsModel.IsActive = true;
                        if (input.FloorTypeId == 2)
                        {
                            if (!string.IsNullOrEmpty(chkBuilding.FloorParkingPrefix))
                            {
                                floorsModel.Name = chkBuilding.FloorParkingPrefix.Trim() + "/" + input.startFloor;//input.Name;
                            }
                            else
                            {
                                floorsModel.Name = input.startFloor.ToString(); ;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(chkBuilding.FloorPrefix))
                            {
                                floorsModel.Name = chkBuilding.FloorPrefix.Trim() + "/" + input.startFloor;//input.Name;
                            }
                            else
                            {
                                floorsModel.Name = input.startFloor.ToString(); ;
                            }
                        }
                        await base.AddAsync(_mapper.Map<Floors>(floorsModel));
                        input.startFloor++;
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
        /// Update a Floor
        /// </summary>
        /// <param name="floorId">Building Identifier</param>
        /// <param name="input">floorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateFloor(long floorId, FloorsModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Floors floor = await Task.Run(() => _dbContext.Floors.Where(x => x.Id == floorId).FirstOrDefault());
                if (floor == null) return "Service Request Not Found!";

                try
                {
                    if (!String.IsNullOrEmpty(input.Name)) floor.Name = input.Name;
                    if (!String.IsNullOrEmpty(input.Code)) floor.Code = input.Code;
                    if (input.FloorTypeId > 0) floor.FloorTypeId = input.FloorTypeId;

                    if (!String.IsNullOrEmpty(floor.Code)) floor.Code = floor.Id.ToString();

                    await base.UpdateAsync(_mapper.Map<Floors>(floor));
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
