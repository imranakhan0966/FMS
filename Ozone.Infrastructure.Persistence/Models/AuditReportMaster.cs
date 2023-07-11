using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class AuditReportMaster
    {
        public AuditReportMaster()
        {
            AuditReportDetail = new HashSet<AuditReportDetail>();
        }

        [Key]
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public long? ClientAuditVisitId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovalStatusId { get; set; }

        [ForeignKey(nameof(ApprovalStatusId))]
        [InverseProperty("AuditReportMaster")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        [ForeignKey(nameof(ClientAuditVisitId))]
        [InverseProperty("AuditReportMaster")]
        public virtual ClientAuditVisit ClientAuditVisit { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.AuditReportMasterCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.AuditReportMasterLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(ClientProjects.AuditReportMaster))]
        public virtual ClientProjects Project { get; set; }
        [InverseProperty("AuditReportMaster")]
        public virtual ICollection<AuditReportDetail> AuditReportDetail { get; set; }
    }
}
