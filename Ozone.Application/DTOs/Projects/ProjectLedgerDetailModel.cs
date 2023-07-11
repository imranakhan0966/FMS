using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Projects
{
    public class ProjectLedgerDetailModel
    {
        public long Id { get; set; }
        public long? ProjectLedgerMasterId { get; set; }
       
        public DateTime? Date { get; set; }
        
        public decimal? ReceiveAmount { get; set; }
        public long? CreatedById { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
       
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
