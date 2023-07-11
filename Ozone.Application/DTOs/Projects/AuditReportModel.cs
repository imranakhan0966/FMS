using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class AuditReportModel
    {
        public long Id { get; set; }
        public long? AuditDocumentTypeId { get; set; }
        public string AuditDocumentName { get; set; }
        public string DocumentFilePath { get; set; }
        public IFormFile File { get; set; }
        public string DocumentContentType { get; set; }
    
        public DateTime? UploadDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        public long? LastModifiedById { get; set; }
       
        public DateTime? CreatedDate { get; set; }
       
        public DateTime? LastModifiedDate { get; set; }
        public long? ProjectId { get; set; }
        public long? AuditVisitId { get; set; }

    }
    public class GetPagedAuditReportModel
    {
        public int TotalCount { get; set; }
        public List<AuditReportModel> AuditReportModel { get; set; }
    }
}
