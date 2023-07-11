using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ClientAuditVisit
    {
        public ClientAuditVisit()
        {
            AuditReport = new HashSet<AuditReport>();
            AuditReportMaster = new HashSet<AuditReportMaster>();
            QcHistory = new HashSet<QcHistory>();
            QcMasterComments = new HashSet<QcMasterComments>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public long? ProjectId { get; set; }
        public long? VisitTypeId { get; set; }
        public long? VisitStatusId { get; set; }
        public long? JustifiedPersonId { get; set; }
        public long? TechnicalExpertId { get; set; }
        [StringLength(200)]
        public string Duration { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? VisitDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        public long? LeadAuditorId { get; set; }
        public long? Auditor1Id { get; set; }
        public long? Auditor2Id { get; set; }
        public long? Auditor3Id { get; set; }
        public long? Auditor4Id { get; set; }
        public long? Auditor5Id { get; set; }
        public string VerificationLevel { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string AuditPlanFilePath { get; set; }
        public string AuditPlanContentType { get; set; }
        public long? ReviewerId { get; set; }
        public long? OrganizationId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReviewDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SubmisionDate { get; set; }
        public long? VisitLevelId { get; set; }

        [ForeignKey(nameof(Auditor1Id))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitAuditor1))]
        public virtual SecUser Auditor1 { get; set; }
        [ForeignKey(nameof(Auditor2Id))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitAuditor2))]
        public virtual SecUser Auditor2 { get; set; }
        [ForeignKey(nameof(Auditor3Id))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitAuditor3))]
        public virtual SecUser Auditor3 { get; set; }
        [ForeignKey(nameof(Auditor4Id))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitAuditor4))]
        public virtual SecUser Auditor4 { get; set; }
        [ForeignKey(nameof(Auditor5Id))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitAuditor5))]
        public virtual SecUser Auditor5 { get; set; }
        [ForeignKey(nameof(JustifiedPersonId))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitJustifiedPerson))]
        public virtual SecUser JustifiedPerson { get; set; }
        [ForeignKey(nameof(LeadAuditorId))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitLeadAuditor))]
        public virtual SecUser LeadAuditor { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("ClientAuditVisit")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(ClientProjects.ClientAuditVisit))]
        public virtual ClientProjects Project { get; set; }
        [ForeignKey(nameof(ReviewerId))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitReviewer))]
        public virtual SecUser Reviewer { get; set; }
        [ForeignKey(nameof(TechnicalExpertId))]
        [InverseProperty(nameof(SecUser.ClientAuditVisitTechnicalExpert))]
        public virtual SecUser TechnicalExpert { get; set; }
        [ForeignKey(nameof(VisitLevelId))]
        [InverseProperty("ClientAuditVisit")]
        public virtual VisitLevel VisitLevel { get; set; }
        [ForeignKey(nameof(VisitStatusId))]
        [InverseProperty("ClientAuditVisit")]
        public virtual VisitStatus VisitStatus { get; set; }
        [ForeignKey(nameof(VisitTypeId))]
        [InverseProperty("ClientAuditVisit")]
        public virtual VisitType VisitType { get; set; }
        [InverseProperty("AuditVisit")]
        public virtual ICollection<AuditReport> AuditReport { get; set; }
        [InverseProperty("ClientAuditVisit")]
        public virtual ICollection<AuditReportMaster> AuditReportMaster { get; set; }
        [InverseProperty("ClientAuditVisit")]
        public virtual ICollection<QcHistory> QcHistory { get; set; }
        [InverseProperty("ClientAuditVisit")]
        public virtual ICollection<QcMasterComments> QcMasterComments { get; set; }
    }
}
