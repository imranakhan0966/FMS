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
    public interface ITenantBuildingService
    {
        /// <summary>
        /// Gets All Building
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of building
        /// </returns>
        Task<List<BuildingsModel>> GetAllBuildings(AdvanceQueryParameter queryParameter);

        /// <summary>
        /// Gets a Building
        /// </summary>
        /// <param name="BuildingId">Building identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Building
        /// </returns>
        Task<BuildingsModel> GetBuildingById(long BuildingId);

        /// <summary>
        /// Insert a Building
        /// </summary>
        /// <param name="input">BuildingsModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> InsertBuilding(BuildingsModel input);

        /// <summary>
        /// Update a ServiceRequest
        /// </summary>
        /// <param name="buildingId">Building Identifier</param>
        /// <param name="input">ServiceRequest object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> UpdateBuilding(long buildingId, BuildingsModel input);
    }
}
