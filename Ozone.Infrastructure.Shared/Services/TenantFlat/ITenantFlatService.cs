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
    public interface ITenantFlatService
    {
        /// <summary>
        /// Gets All Flat
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Flat
        /// </returns>
        Task<List<FlatModel>> GetAllFlats(AdvanceQueryParameter queryParameter);

        /// <summary>
        /// Gets All Flat
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Flat
        /// </returns>
        Task<List<FlatModel>> GetAllFlatsByUpdate(AdvanceQueryParameter queryParameter);

        /// <summary>
        /// Insert a Flat
        /// </summary>
        /// <param name="input">FlatModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> InsertFlat(FlatDetailModel input);

        /// <summary>
        /// Gets a Flat
        /// </summary>
        /// <param name="FlatId">Flat identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Flat
        /// </returns>
        Task<FlatModel> GetFlatById(long FlatId);

        /// <summary>
        /// Update a FLat
        /// </summary>
        /// <param name="flatId">Flat Identifier</param>
        /// <param name="input">FlatModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> UpdateFlat(long flatId, FlatModel input);
    }
}
