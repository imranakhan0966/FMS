using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class ProjectSA8000Model
    {
        public long Id { get; set; }
       
        public string Code { get; set; }
        public long? ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public long? RiskId { get; set; }
        public string RiskName { get; set; }
        public long? EacodeId { get; set; }
        public string Eacodename { get; set; }
        public long? NaceCodeId { get; set; }
        public string NaceCodeName { get; set; }
        public long? ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public long? AccreditationId { get; set; }
        public string AccreditationName { get; set; }
        public string Scope { get; set; }
       
        public string PreAuditDuration { get; set; }
     
        public string DurationStage1 { get; set; }
      
        public string DurationStage2 { get; set; }
        public long? SurveillanceVisitFrequencyId { get; set; }
        public string SurveillanceVisitFrequencyName { get; set; }
        public long? SurveillanceMethodId { get; set; }
        public string SurveillanceMethodName { get; set; }
        public string NoOfSurveillanceVisits { get; set; }
        public double? Applicatonfee { get; set; }
        public double? PreAuditfee { get; set; }
        public double? Assessmentfee { get; set; }
        public double? Survfee { get; set; }
        public long? ExpensesId { get; set; }
        public string ExpensesName { get; set; }
        public IFormFile DocumentFile { get; set; }
        public string ApplicationFormPath { get; set; }
        public string ApplicationContentType { get; set; }
        public string Remarks { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        public string CreatedByName { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        public string LastModifiedByName { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string ApprovalStatusName { get; set; }
    }
}
