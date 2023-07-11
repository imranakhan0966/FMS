using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs.Architectures
{
    public class ParkingSlotDetailModel
    {
        public long? FloorId { get; set; }
        public long? totalSlots { get; set; }
        public long? startSlot { get; set; }
        public long? BuildingId { get; set; }
        public string Name { get; set; }
    }
}
