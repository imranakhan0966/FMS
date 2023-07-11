using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Security
{
   public class SecUserTypeModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public int? UserLevel { get; set; }

    }
}
