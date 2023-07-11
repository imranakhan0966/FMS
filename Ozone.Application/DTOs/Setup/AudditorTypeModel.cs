using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class AudditorTypeModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public long? CreatedBy { get; set; }

        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
