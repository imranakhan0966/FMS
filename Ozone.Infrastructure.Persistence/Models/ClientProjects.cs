using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ClientProjects
    {
        public ClientProjects()
        {
            AuditReport = new HashSet<AuditReport>();
            AuditReportMaster = new HashSet<AuditReportMaster>();
            ClientAuditVisit = new HashSet<ClientAuditVisit>();
            ProjectHigg = new HashSet<ProjectHigg>();
            ProjectIso = new HashSet<ProjectIso>();
            ProjectLedger = new HashSet<ProjectLedger>();
            ProjectRemarksHistory = new HashSet<ProjectRemarksHistory>();
            ProjectSa8000 = new HashSet<ProjectSa8000>();
            ProjectSlcp = new HashSet<ProjectSlcp>();
            QcHistory = new HashSet<QcHistory>();
            QcMasterComments = new HashSet<QcMasterComments>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string ProjectCode { get; set; }
        public long? ClientSiteId { get; set; }
        public long StandardId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        public long? VerificationTypeId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovalStatusId { get; set; }
        public long? ProjectTypeId { get; set; }
        public string Remarks { get; set; }
        public string ContractFilePath { get; set; }
        public string ContractFileContent { get; set; }
        public long? ProjectAmountId { get; set; }
        public long? ClientId { get; set; }

        [ForeignKey(nameof(ApprovalStatusId))]
        [InverseProperty(nameof(ProjectsApprovalStatus.ClientProjects))]
        public virtual ProjectsApprovalStatus ApprovalStatus { get; set; }
        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(SecUser.ClientProjectsApprovedBy))]
        public virtual SecUser ApprovedBy { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientProjects")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(ClientSiteId))]
        [InverseProperty(nameof(ClientSites.ClientProjects))]
        public virtual ClientSites ClientSite { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ClientProjectsCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ClientProjectsLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(ProjectAmountId))]
        [InverseProperty("ClientProjects")]
        public virtual ProjectAmount ProjectAmount { get; set; }
        [ForeignKey(nameof(ProjectTypeId))]
        [InverseProperty("ClientProjects")]
        public virtual ProjectType ProjectType { get; set; }
        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.ClientProjects))]
        public virtual Certification Standard { get; set; }
        [ForeignKey(nameof(VerificationTypeId))]
        [InverseProperty("ClientProjects")]
        public virtual VerificationType VerificationType { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<AuditReport> AuditReport { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<AuditReportMaster> AuditReportMaster { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisit { get; set; }
        [InverseProperty("ClientProject")]
        public virtual ICollection<ProjectHigg> ProjectHigg { get; set; }
        [InverseProperty("ClientProject")]
        public virtual ICollection<ProjectIso> ProjectIso { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<ProjectLedger> ProjectLedger { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<ProjectRemarksHistory> ProjectRemarksHistory { get; set; }
        [InverseProperty("ClientProject")]
        public virtual ICollection<ProjectSa8000> ProjectSa8000 { get; set; }
        [InverseProperty("ClientProject")]
        public virtual ICollection<ProjectSlcp> ProjectSlcp { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<QcHistory> QcHistory { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<QcMasterComments> QcMasterComments { get; set; }
    }
}
