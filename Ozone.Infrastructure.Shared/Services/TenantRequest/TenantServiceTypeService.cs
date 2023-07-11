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
    public class TenantServiceTypeService : GenericRepositoryAsync<ServiceType>, ITenantServiceTypeService
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

        public TenantServiceTypeService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        SieveProcessor sieveProcessor,
         // IUserSessionHelper userSession,
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
        /// Gets All ServicesType
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceTypes
        /// </returns>
        public async Task<List<ServiceTypeModel>> GetALLServicesType()
        {
            var result = new List<ServiceTypeModel>();

            var list = await Task.Run(() => _dbContext.ServiceType.Where(x => x.IsDeleted == false && x.IsActive == true).ToList());
            result = _mapper.Map<List<ServiceTypeModel>>(list);
            return result;
        }

        /// <summary>
        /// Insert a Floor
        /// </summary>
        /// <param name="input">FloorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> InsertServiceType(ServiceTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    input.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    await base.AddAsync(_mapper.Map<ServiceType>(input));
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
        /// Gets a ServiceTypes
        /// </summary>
        /// <param name="ServiceTypesId">ServiceTypes identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a ServiceTypes
        /// </returns>
        public async Task<ServiceTypeModel> GetServiceTypesById(long ServiceTypesId)
        {
            var result = new ServiceTypeModel();
            var obj = await Task.Run(() => _dbContext.ServiceType.Where(x => x.Id == ServiceTypesId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<ServiceTypeModel>(obj);
            return result;
        }

        /// <summary>
        /// Update a Floor
        /// </summary>
        /// <param name="ServiceTypeId">ServiceType Identifier</param>
        /// <param name="input">floorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateServiceTypes(long ServiceTypeId, ServiceTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ServiceType serviceType = await Task.Run(() => _dbContext.ServiceType.Where(x => x.Id == ServiceTypeId).FirstOrDefault());
                if (serviceType == null) return "Service Request Not Found!";

                try
                {
                    if (!String.IsNullOrEmpty(input.Name)) serviceType.Name = input.Name;
                    if (!String.IsNullOrEmpty(input.Description)) serviceType.Description = input.Description;
                    if (input.IsActive != null) serviceType.IsActive = input.IsActive;
                    if (input.IsDeleted != null) serviceType.IsDeleted = input.IsDeleted;
                    
                    if (input.LastModifiedById > 0) {
                        serviceType.LastModifiedById = input.LastModifiedById;
                        serviceType.LastModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    } 

                    await base.UpdateAsync(_mapper.Map<ServiceType>(serviceType));
                    await _unitOfWork.SaveChangesAsync();
                    transaction.Commit();
                    if(input.IsActive == false && input.IsDeleted == true) return "Record Deleted";
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
