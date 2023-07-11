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
    public interface ITenantRequestService
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
        /// Gets a ServiceTypes
        /// </summary>
        /// <param name="ServiceTypesId">ServiceTypes identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a ServiceTypes
        /// </returns>
        Task<ServiceTypeModel> GetServiceTypesById(long ServiceTypesId);

        /// <summary>
        /// Gets All Priorities
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Priority
        /// </returns>
        Task<List<PriorityModel>> GetAllPriorities();

        /// <summary>
        /// Gets a Priority
        /// </summary>
        /// <param name="PriorityId">Priority identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Priority
        /// </returns>
        Task<PriorityModel> GetPriorityById(long id);

        /// <summary>
        /// Gets All ServiceStatuses
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceStatus
        /// </returns>
        Task<List<ServiceStatusModel>> GetAllServiceStatus();

        /// <summary>
        /// Gets a ServiceStatus
        /// </summary>
        /// <param name="ServiceStatusId">ServiceStatus identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a ServiceStatus
        /// </returns>
        Task<ServiceStatusModel> GetServiceStatusById(long ServiceStatusId);

        /// <summary>
        /// Gets All ServiceRequest
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceRequest
        /// </returns>
        Task<List<ServiceRequestModel>> GetAllServiceRequest();

        /// <summary>
        /// Gets All ServiceRequest
        /// </summary>
        /// <param name="ServiceStatusId">ServiceStatus identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceRequest
        /// </returns>
        Task<List<ServiceRequestModel>> GetAllServiceRequest(AdvanceQueryParameter queryParameter);

        /// <summary>
        /// Gets a ServiceRequest
        /// </summary>
        /// <param name="ServiceRequestId">ServiceRequest identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a ServiceRequest
        /// </returns>
        Task<ServiceRequestModel> GetServiceRequestById(long ServiceRequestId);

        /// <summary>
        /// Insert a ServiceRequest
        /// </summary>
        /// <param name="input">ServiceRequest object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> InsertServiceRequest(ServiceRequestModel input);

        /// <summary>
        /// Update a ServiceRequest
        /// </summary>
        /// <param name="input">ServiceRequest object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> UpdateServiceRequest(long ServiceRequestId, ServiceRequestModel input);
    }
}
