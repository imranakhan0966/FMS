using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ProjectLedger
    {
        public ProjectLedger()
        {
            ProjectLedgerDetail = new HashSet<ProjectLedgerDetail>();
        }

        [Key]
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal? ReceivedAmount { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedByDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ProjectLedgerCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ProjectLedgerLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(ClientProjects.ProjectLedger))]
        public virtual ClientProjects Project { get; set; }
        [InverseProperty("ProjectLedgerMaster")]
        public virtual ICollection<ProjectLedgerDetail> ProjectLedgerDetail { get; set; }
    }
}
