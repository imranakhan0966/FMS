using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class QCHistoryModel
    {
        public long Id { get; set; }
        public string Remarks { get; set; }
        public long? ProjectId { get; set; }

        public long? QcdocumentsListId { get; set; }
        public long? RemarksById { get; set; }
        public string RemarksBy { get; set; }

        public DateTime? RemarksDate { get; set; }
        public long? RemarksUpdateById { get; set; }

        public DateTime? RenarksUpdateDate { get; set; }
        public bool? IsDeleted { get; set; }
        public long? QcStatusId { get; set; }
        public string qcRemarksFile { get; set; }
      
       // public string qcRemarksFS { get; set; }
        public long? clientAuditVisitId { get; set; }


        public string DocumentContentType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentContent { get; set; }
        //public string DocumentFilePath { get; set; }
    }
    //public class QCHistoryModelTow
    //{
    //    public long id { get; set; }
        
    //    public long? projectId { get; set; }

        

       
    //    public IFormFile qcRemarksFile { get; set; }
    //}
    

}
