using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class CertificationBodyModel
    {
        public long Id { get; set; }
  
        public string Code { get; set; }
        
        public string Body { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
     
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedy { get; set; }
      
        public DateTime? LastModifiedDate { get; set; }
    }
}
