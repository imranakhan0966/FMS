using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Architectures
{
    public class FloorTypeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}