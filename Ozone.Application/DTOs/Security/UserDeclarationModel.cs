using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class UserDeclarationModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }

        public string CompanyName { get; set; }
        public long? ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }

        public string Interest { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string ApprovalStatus { get; set; }
        public int? StartYear { get; set; } 
     
        public int? EndYear { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
