using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class AuditReport
    {
        public AuditReport()
        {
            AuditReportHistory = new HashSet<AuditReportHistory>();
        }

        [Key]
        public long Id { get; set; }
        public long? AuditDocumentTypeId { get; set; }
        public string DocumentFilePath { get; set; }
        public string DocumentContentType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UploadDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long? ProjectId { get; set; }
        public long? AuditVisitId { get; set; }

        [ForeignKey(nameof(AuditDocumentTypeId))]
        [InverseProperty(nameof(AuditDocumentsType.AuditReport))]
        public virtual AuditDocumentsType AuditDocumentType { get; set; }
        [ForeignKey(nameof(AuditVisitId))]
        [InverseProperty(nameof(ClientAuditVisit.AuditReport))]
        public virtual ClientAuditVisit AuditVisit { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.AuditReportCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.AuditReportLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(ClientProjects.AuditReport))]
        public virtual ClientProjects Project { get; set; }
        [InverseProperty("AuditReport")]
        public virtual ICollection<AuditReportHistory> AuditReportHistory { get; set; }
    }
}
