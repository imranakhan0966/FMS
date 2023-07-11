using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public class QcCommentsMasterModel
    {
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public long? QcDocumentsId { get; set; }
        public long? QcStatusId { get; set; }
        public string StatusName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
    
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
      
        public DateTime? LastModifiedDate { get; set; }
        public long? ClientAuditVisitId { get; set; }
    }
}
