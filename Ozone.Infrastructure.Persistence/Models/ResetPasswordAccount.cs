using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ResetPasswordAccount
    {
        [Key]
        public long Id { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public long? OrganizationId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedByDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedByDate { get; set; }
        [StringLength(200)]
        public string Body { get; set; }
        public long? UserId { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ResetPasswordAccountCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ResetPasswordAccountLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("ResetPasswordAccount")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.ResetPasswordAccountUser))]
        public virtual SecUser User { get; set; }
    }
}
