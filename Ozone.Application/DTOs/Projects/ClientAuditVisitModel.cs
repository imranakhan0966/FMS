using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class ClientAuditVisitModel
    {
        public long Id { get; set; }
        [ReadOnly(true)]
        public string Code { get; set; }
        public long? ProjectId { get; set; }
        [ReadOnly(true)]
        public string ProjectCode { get; set; }
        public long? VisitTypeId { get; set; }
        [ReadOnly(true)]
        public string VisitTypeName { get; set; }
        public long? VisitStatusId { get; set; }
        [ReadOnly(true)]
        public string VisitStatusName { get; set; }
        public long? JustifiedPersonId { get; set; }
        public string JustifiedPersonName { get; set; }
        public long? TechnicalExpertId { get; set; }
        public string TechnicalExpertName { get; set; }
        public string Duration { get; set; }
   
        public DateTime? VisitDate { get; set; }
       
        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        public long? LeadAuditorId { get; set; }
        public string LeadAuditorName { get; set; }
        public long? Auditor1Id { get; set; }
        public string Auditor1Name { get; set; }
        public long? Auditor2Id { get; set; }
        public string Auditor2Name { get; set; }
        public long? Auditor3Id { get; set; }
        public string Auditor3Name { get; set; }
        public long? Auditor4Id { get; set; }
        public string Auditor4Name { get; set; }
        public long? Auditor5Id { get; set; }
        public string Auditor5Name { get; set; }

        public string VerificationLevel { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
    
        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovedById { get; set; }
     
        public DateTime? ApprovedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public IFormFile File { get; set; }
        public string AuditPlanFilePath { get; set; }
        public string AuditPlanContentType { get; set; }
        public string StandardName { get; set; }
        public long? ReviewerId { get; set; }
        public string ReviewerName { get; set; }
        public long? StandardId { get; set; }
        public long? OrganizationId { get; set; }
        public long? ClientId{ get; set; }

        public DateTime? ReviewDate { get; set; }
       
        public DateTime? SubmisionDate { get; set; }
        public long? VisitLevelId { get; set; }
        public string VisitLevelName { get; set; }
        public string ClientName { get; set; }

    }
    public class GetPagedClientAuditVisitModel
    {
        public int TotalCount { get; set; }
        public List<ClientAuditVisitModel> ClientAuditModel { get; set; }
    }
}
