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
    public class TenantFloorTypeService : GenericRepositoryAsync<FloorType>, ITenantFloorTypeService
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

        public TenantFloorTypeService(
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
        /// Gets All Floor Types
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of FloorType
        /// </returns>
        public async Task<List<FloorTypeModel>> GetAllFloorsTypes(AdvanceQueryParameter queryParameter)
        {
            var result = new List<FloorTypeModel>();

            var query = _dbContext.FloorType.Select(x => x);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);

            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<FloorTypeModel>>(list);
            return result;
        }

        /// <summary>
        /// Gets a Floor Type
        /// </summary>
        /// <param name="FloorTypeId">FloorType identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Floor
        /// </returns>
        public async Task<FloorTypeModel> GetFloorTypeById(long FloorTypeId)
        {
            var result = new FloorTypeModel();
            var obj = await Task.Run(() => _dbContext.FloorType.Where(x => x.Id == FloorTypeId && x.IsActive == true).SingleOrDefaultAsync());
            result = _mapper.Map<FloorTypeModel>(obj);
            return result;
        }

        /// <summary>
        /// Insert a Floor Type
        /// </summary>
        /// <param name="input">FloorTypeModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> InsertFloorType(FloorTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    await base.AddAsync(_mapper.Map<FloorType>(input));
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
        /// <param name="floorTypeId">Building Identifier</param>
        /// <param name="input">floorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateFloorType(long floorTypeId, FloorTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                FloorType floortype = await Task.Run(() => _dbContext.FloorType.Where(x => x.Id == floorTypeId).FirstOrDefault());
                if (floortype == null) return "Service Request Not Found!";

                try
                {
                    if (!String.IsNullOrEmpty(input.Name)) floortype.Name = input.Name;
                    if (input.IsActive != null) floortype.IsActive = input.IsActive;

                    await base.UpdateAsync(_mapper.Map<FloorType>(floortype));
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
