using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class UserEmploymentModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string JobTitle { get; set; }
        public string Organization { get; set; }
        public string BusinessScope { get; set; }
       
        public int? StartYear { get; set; }
      
        public int? EndYear { get; set; }
        public string DocumentContentType { get; set; }
        public string DocumentsFilePath { get; set; }
        public long? ApprovedBy { get; set; }
     
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
       
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
       
        public DateTime? LastModifiedDate { get; set; }
    }
}
