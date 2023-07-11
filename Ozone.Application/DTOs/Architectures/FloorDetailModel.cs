using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs.Architectures
{
    public class FloorDetailModel
    {
        public string Name { get; set; }
        public long? FloorTypeId { get; set; }
        public long? BuildingId { get; set; }
        public long? totalFloor { get; set; }
        public long? startFloor { get; set; }
    }
}
