using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ProjectLedgerDetail
    {
        [Key]
        public long Id { get; set; }
        public long? ProjectLedgerMasterId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal? ReceiveAmount { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ProjectLedgerDetailCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ProjectLedgerDetailLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(ProjectLedgerMasterId))]
        [InverseProperty(nameof(ProjectLedger.ProjectLedgerDetail))]
        public virtual ProjectLedger ProjectLedgerMaster { get; set; }
    }
}
