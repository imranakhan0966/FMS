using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserAuditorNace
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? StandardId { get; set; }
        [Column("EACodeId")]
        public long? EacodeId { get; set; }
        public long? NaceCodeId { get; set; }
        public long? ApprovalStatusId { get; set; }
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
        public string Remarks { get; set; }

        [ForeignKey(nameof(ApprovalStatusId))]
        [InverseProperty("UserAuditorNace")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        [ForeignKey(nameof(ApprovedBy))]
        [InverseProperty(nameof(SecUser.UserAuditorNaceApprovedByNavigation))]
        public virtual SecUser ApprovedByNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.UserAuditorNaceCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(EacodeId))]
        [InverseProperty("UserAuditorNace")]
        public virtual Eacode Eacode { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.UserAuditorNaceLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(NaceCodeId))]
        [InverseProperty("UserAuditorNace")]
        public virtual NaceCode NaceCode { get; set; }
        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.UserAuditorNace))]
        public virtual Certification Standard { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserAuditorNaceUser))]
        public virtual SecUser User { get; set; }
    }
}
