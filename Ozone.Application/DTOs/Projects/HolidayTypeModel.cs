using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class HolidayTypeModel
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
      
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
