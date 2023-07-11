using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class AuditReportHistory
    {
        [Key]
        public long Id { get; set; }
        public long? AuditReportId { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string Remarks { get; set; }
        public long? RemarksById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RemarksDate { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(ApprovalStatusId))]
        [InverseProperty("AuditReportHistory")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        [ForeignKey(nameof(AuditReportId))]
        [InverseProperty("AuditReportHistory")]
        public virtual AuditReport AuditReport { get; set; }
        [ForeignKey(nameof(RemarksById))]
        [InverseProperty(nameof(SecUser.AuditReportHistory))]
        public virtual SecUser RemarksBy { get; set; }
    }
}
