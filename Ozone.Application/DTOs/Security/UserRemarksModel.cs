using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class UserRemarksModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string ApprovalStatus { get; set; }
        public string Remarks { get; set; }
        public long? RemarksById { get; set; }
        public string RemarksBy { get; set; }

        public DateTime? RemarksDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
