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
    public interface ITenantParkingSlotService
    {
        /// <summary>
        /// Gets All Parking Slots
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Parking Slots
        /// </returns>
        Task<List<ParkingSlotModel>> GetAllParkingSlots(AdvanceQueryParameter queryParameter);

        /// <summary>
        /// Insert a Parking Slot
        /// </summary>
        /// <param name="input">ParkingSlotModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> InsertParkingSlot(ParkingSlotDetailModel input);

        /// <summary>
        /// Gets a Parking Slot
        /// </summary>
        /// <param name="ParkingSlotId">ParkingSlot identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Parking Slot
        /// </returns>
        Task<ParkingSlotModel> GetParkingSlotById(long ParkingSlotId);

        /// <summary>
        /// Update a Parking Slot
        /// </summary>
        /// <param name="parkingSlotId">ParkingSlot Identifier</param>
        /// <param name="input">ParkingSlotModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<string> UpdateParkingSlot(long parkingSlotId, ParkingSlotModel input);
    }
}
