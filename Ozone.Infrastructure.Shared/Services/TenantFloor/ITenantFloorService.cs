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
    public interface ITenantFloorService
    {
        
        /// <summary>
        /// Gets All Floor
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Floor
        /// </returns>
        Task<List<FloorsModel>> GetAllFloors(AdvanceQueryParameter queryParameter);

        /// <summary>
        /// Gets a Floor
        /// </summary>
        /// <param name="FloorId">Floor identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Floor
        /// </returns>
        Task<FloorsModel> GetFloorById(long FloorId);

        /// <summary>
        /// Insert a Floor
        /// </summary>
        /// <param name="input">FloorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> InsertFloor(FloorDetailModel input);

        /// <summary>
        /// Update a Floor
        /// </summary>
        /// <param name="floorId">Building Identifier</param>
        /// <param name="input">floorModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> UpdateFloor(long floorId, FloorsModel input);

    }
}
