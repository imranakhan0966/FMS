using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserEmployment
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        [StringLength(200)]
        public string JobTitle { get; set; }
        public string Organization { get; set; }
        public string BusinessScope { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string DocumentContentType { get; set; }
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
        [InverseProperty(nameof(SecUser.UserEmploymentApprovedByNavigation))]
        public virtual SecUser ApprovedByNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.UserEmploymentCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.UserEmploymentLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserEmploymentUser))]
        public virtual SecUser User { get; set; }
    }
}
