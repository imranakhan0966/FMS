using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class UserAcademicModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Qualification { get; set; }
        public string Details { get; set; }
        
        public string Institution { get; set; }
       
        public int StartYear { get; set; }
       
        public int EndYear { get; set; }
        public IFormFile DocumentFile { get; set; }
        public string DocumentContentType { get; set; }
        public string DocumentFilePath { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedById { get; set; }
       
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedById { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
       
        public DateTime? LastModifiedDate { get; set; }

    }
}
