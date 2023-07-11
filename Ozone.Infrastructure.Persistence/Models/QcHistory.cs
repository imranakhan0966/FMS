using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class QcHistory
    {
        [Key]
        public long Id { get; set; }
        public string Remarks { get; set; }
        public long? ProjectId { get; set; }
        [Column("QCDocumentsListId")]
        public long? QcdocumentsListId { get; set; }
        public long? RemarksById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RemarksDate { get; set; }
        public long? RemarksUpdateById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RenarksUpdateDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string DocumentContentType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentContent { get; set; }
        public long? ClientAuditVisitId { get; set; }

        [ForeignKey(nameof(ClientAuditVisitId))]
        [InverseProperty("QcHistory")]
        public virtual ClientAuditVisit ClientAuditVisit { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(ClientProjects.QcHistory))]
        public virtual ClientProjects Project { get; set; }
        [ForeignKey(nameof(QcdocumentsListId))]
        [InverseProperty("QcHistory")]
        public virtual QcdocumentsList QcdocumentsList { get; set; }
        [ForeignKey(nameof(RemarksById))]
        [InverseProperty(nameof(SecUser.QcHistory))]
        public virtual SecUser RemarksBy { get; set; }
    }
}
