using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    [Table("UserCPD")]
    public partial class UserCpd
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Course { get; set; }
        public string Organization { get; set; }
        public string Details { get; set; }
        public long? StandardId { get; set; }
        public int? Year { get; set; }
        public long? TypeId { get; set; }
        [StringLength(10)]
        public string Hours { get; set; }
        public string DocumentsContentType { get; set; }
        public string DocumentsFilePath { get; set; }
        public long? ApprovedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(ApprovedBy))]
        [InverseProperty(nameof(SecUser.UserCpdApprovedByNavigation))]
        public virtual SecUser ApprovedByNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.UserCpdCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.UserCpdLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.UserCpd))]
        public virtual Certification Standard { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserCpdUser))]
        public virtual SecUser User { get; set; }
    }
}
