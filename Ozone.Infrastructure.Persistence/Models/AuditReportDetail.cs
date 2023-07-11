using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class AuditReportDetail
    {
        [Key]
        public long Id { get; set; }
        public long? AuditReportMasterId { get; set; }
        public long? AuditDocumentTypeId { get; set; }
        public string DocumentFilePath { get; set; }
        public string DocumentContentType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UploadDate { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(AuditDocumentTypeId))]
        [InverseProperty(nameof(AuditDocumentsType.AuditReportDetail))]
        public virtual AuditDocumentsType AuditDocumentType { get; set; }
        [ForeignKey(nameof(AuditReportMasterId))]
        [InverseProperty("AuditReportDetail")]
        public virtual AuditReportMaster AuditReportMaster { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.AuditReportDetailCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.AuditReportDetailLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
    }
}
