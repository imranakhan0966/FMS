using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs.Architectures
{
    public class FlatDetailModel
    {
        public long? totalApartment { get; set; }
        public long? startApartment { get; set; }
        public string Name { get; set; }
        public long? ParkingSlotId { get; set; }
        public long? FloorId { get; set; }
        public long? BuildingId { get; set; }
        public bool? IsAllotted { get; set; }

    }
}
