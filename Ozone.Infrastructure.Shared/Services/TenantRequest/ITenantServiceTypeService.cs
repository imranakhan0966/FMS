using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure
{
    public interface ITenantServiceTypeService
    {
        /// <summary>
        /// Gets All ServicesType
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceTypes
        /// </returns>
        Task<List<ServiceTypeModel>> GetALLServicesType();

        /// <summary>
        /// Insert a Floor
        /// </summary>
        /// <param name="input">FloorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> InsertServiceType(ServiceTypeModel input);

        /// <summary>
        /// Gets a ServiceTypes
        /// </summary>
        /// <param name="ServiceTypesId">ServiceTypes identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a ServiceTypes
        /// </returns>
        Task<ServiceTypeModel> GetServiceTypesById(long ServiceTypesId);

        /// <summary>
        /// Update a Floor
        /// </summary>
        /// <param name="ServiceTypeId">ServiceType Identifier</param>
        /// <param name="input">floorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> UpdateServiceTypes(long ServiceTypeId, ServiceTypeModel input);
    }
}
