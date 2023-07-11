using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserAudit
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? StandardId { get; set; }
        public string Organization { get; set; }
        [Column("EACodeId")]
        public long? EacodeId { get; set; }
        public long? NaceCodeId { get; set; }
        public long? AuditTypeId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Duration { get; set; }
        public int? Year { get; set; }
        public long? CertificationBodyId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(200)]
        public string AuditLevel { get; set; }

        [ForeignKey(nameof(ApprovedBy))]
        [InverseProperty(nameof(SecUser.UserAuditApprovedByNavigation))]
        public virtual SecUser ApprovedByNavigation { get; set; }
        [ForeignKey(nameof(AuditTypeId))]
        [InverseProperty("UserAudit")]
        public virtual AuditType AuditType { get; set; }
        [ForeignKey(nameof(CertificationBodyId))]
        [InverseProperty("UserAudit")]
        public virtual CertificationBody CertificationBody { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.UserAuditCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(EacodeId))]
        [InverseProperty("UserAudit")]
        public virtual Eacode Eacode { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.UserAuditLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(NaceCodeId))]
        [InverseProperty("UserAudit")]
        public virtual NaceCode NaceCode { get; set; }
        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.UserAudit))]
        public virtual Certification Standard { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserAuditUser))]
        public virtual SecUser User { get; set; }
    }
}
