using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class UserProfessionalModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Body { get; set; }
        public string Qualification { get; set; }
        public string Details { get; set; }
      
        public int? Year { get; set; }
        public IFormFile DocumentFile { get; set; }
        public string DocumentsContentType { get; set; }
        public string DocumentsFilePath { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedBy { get; set; }
       
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
       
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
      
        public DateTime? LastModifiedDate { get; set; }
    }
}
