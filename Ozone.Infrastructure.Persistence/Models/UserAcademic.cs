using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserAcademic
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Qualification { get; set; }
        public string Details { get; set; }
        [StringLength(200)]
        public string Institution { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string DocumentContentType { get; set; }
        public string DocumentFilePath { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long UserId { get; set; }

        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(SecUser.UserAcademicApprovedBy))]
        public virtual SecUser ApprovedBy { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.UserAcademicCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.UserAcademicLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserAcademicUser))]
        public virtual SecUser User { get; set; }
    }
}
