using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserConsultancy
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Organization { get; set; }
        public long? StandardId { get; set; }
        public int? DurationDays { get; set; }
        public int? Year { get; set; }
        [Column("EACodeId")]
        public long? EacodeId { get; set; }
        public long? NaceCodeId { get; set; }
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

        [ForeignKey(nameof(ApprovedBy))]
        [InverseProperty(nameof(SecUser.UserConsultancyApprovedByNavigation))]
        public virtual SecUser ApprovedByNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.UserConsultancyCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(EacodeId))]
        [InverseProperty("UserConsultancy")]
        public virtual Eacode Eacode { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.UserConsultancyLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(NaceCodeId))]
        [InverseProperty("UserConsultancy")]
        public virtual NaceCode NaceCode { get; set; }
        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.UserConsultancy))]
        public virtual Certification Standard { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserConsultancyUser))]
        public virtual SecUser User { get; set; }
    }
}
