using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class UserAuditModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? StandardId { get; set; }
        public string StandardName { get; set; }
        public string Organization { get; set; }
       
        public long? EacodeId { get; set; }
        public string EacodeName { get; set; }
        public long? NaceCodeId { get; set; }
        public string NacecodeName{ get; set; }
        public long? AuditTypeId { get; set; }
        public string AuditTypeName { get; set; }
        public decimal? Duration { get; set; }
        
        public int? Year { get; set; }
        public long? CertificationBodyId { get; set; }
        public string CertificationBodyName { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedBy { get; set; }
       
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
     
        public DateTime? LastModifiedDate { get; set; }
        public string AuditLevel { get; set; }
        

    }
}
