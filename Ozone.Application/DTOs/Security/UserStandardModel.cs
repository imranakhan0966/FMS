using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class UserStandardModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? StandardId { get; set; }
        public string StandardName { get; set; }


        public long? AuditorTypeId { get; set; }
        public string AuditorTypeName { get; set; }
        public long? CourseTypeId { get; set; }
        public string CourseTypeName { get; set; }
        public DateTime? CourseDate { get; set; }
     
        public DateTime? PreValidDate { get; set; }
       
        public DateTime? ValidationDate { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string ApprovalStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public long? Approvedby { get; set; }
      
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        
        public DateTime? LastModifiedDate { get; set; }

        public string UserName { get; set; }
        public long? OrganizationId { get; set; }
        public string DocumentFilePath { get; set; }
        public string DocumentContentType { get; set; }
        public IFormFile DocumentFile { get; set; }
        public string Remarks { get; set; }
        


    }
}
