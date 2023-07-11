using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class QCDocumentsListModel
    {
        public long Id { get; set; }
    
        public string Code { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
        public long? OrganizationId { get; set; }
        public long? StandardId { get; set; }
        public string StandardName { get; set; }
        public long? CreatedById { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
     
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string StatusName { get; set; }
        public long? StatusId { get; set; }
      public List<QCHistoryModel> QCHistoryModel { get; set; }
}
    public class GetPagedQCDocumentsListModel
    {
        public ClientAuditVisitModel ClientAuditVisitModel { get; set; }
        public List<QCDocumentsListModel> QCDocumentsListModel { get; set; }
    }
}
