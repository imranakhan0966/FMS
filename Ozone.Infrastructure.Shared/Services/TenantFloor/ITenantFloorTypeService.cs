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
    public interface ITenantFloorTypeService
    {

        /// <summary>
        /// Gets All Floor Types
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of FloorType
        /// </returns>
        Task<List<FloorTypeModel>> GetAllFloorsTypes(AdvanceQueryParameter queryParameter);
        
        /// <summary>
        /// Insert a Floor
        /// </summary>
        /// <param name="input">FloorTypeModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> InsertFloorType(FloorTypeModel input);

        /// <summary>
        /// Gets a Floor
        /// </summary>
        /// <param name="FloorTypeId">FloorType identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a FloorType
        /// </returns>
        Task<FloorTypeModel> GetFloorTypeById(long FloorId);


        /// <summary>
        /// Update a Floor
        /// </summary>
        /// <param name="floorTypeId">Building Identifier</param>
        /// <param name="input">FloorTypeModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> UpdateFloorType(long floorTypeId, FloorTypeModel input);

    }
}
