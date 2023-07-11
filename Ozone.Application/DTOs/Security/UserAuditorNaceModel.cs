using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class UserAuditorNaceModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? StandardId { get; set; }
       public string StandardName { get; set; }
        public long? EacodeId { get; set; }
        public string EacodeName { get; set; }
        public long? NaceCodeId { get; set; }
        public string NacecodeName { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string ApprovalStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedBy { get; set; }
       
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
       
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
      
        public DateTime? LastModifiedDate { get; set; }
        public string UserName { get; set; }
        public string Remarks { get; set; }
    }
}
