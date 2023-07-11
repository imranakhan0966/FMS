using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class AuditDocumentsType
    {
        public AuditDocumentsType()
        {
            AuditReport = new HashSet<AuditReport>();
            AuditReportDetail = new HashSet<AuditReportDetail>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifieddate { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.AuditDocumentsTypeCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.AuditDocumentsTypeLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [InverseProperty("AuditDocumentType")]
        public virtual ICollection<AuditReport> AuditReport { get; set; }
        [InverseProperty("AuditDocumentType")]
        public virtual ICollection<AuditReportDetail> AuditReportDetail { get; set; }
    }
}
