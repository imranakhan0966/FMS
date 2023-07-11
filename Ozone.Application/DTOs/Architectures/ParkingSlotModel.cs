using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Architectures
{
    public class ParkingSlotModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long? FloorId { get; set; }
        public long? BuildingId { get; set; }
        public bool? isAllotted { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
