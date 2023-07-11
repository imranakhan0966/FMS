using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserProfessional
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Body { get; set; }
        public string Qualification { get; set; }
        public string Details { get; set; }
        public int? Year { get; set; }
        public string DocumentsContentType { get; set; }
        public string DocumentsFilePath { get; set; }
        public bool? IsActive { get; set; }
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
        [InverseProperty(nameof(SecUser.UserProfessionalApprovedByNavigation))]
        public virtual SecUser ApprovedByNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.UserProfessionalCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.UserProfessionalLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserProfessionalUser))]
        public virtual SecUser User { get; set; }
    }
}
