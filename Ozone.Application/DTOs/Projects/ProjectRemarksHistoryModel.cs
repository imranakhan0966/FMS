using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class ProjectRemarksHistoryModel
    {

        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public string ProjectTypeName{ get; set; }
        public long? ApprovalStatusId { get; set; }
        public string ApprovalStatusName { get; set; }
        public string Remarks { get; set; }
        public long? RemarksById { get; set; }
        public string RemarksBy { get; set; }

        public DateTime? RemarksDate { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ClientId { get; set; }


    }
}
