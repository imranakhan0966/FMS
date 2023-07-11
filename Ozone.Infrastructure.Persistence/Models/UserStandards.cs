using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserStandards
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? StandardId { get; set; }
        public long? AuditorTypeId { get; set; }
        public long? CourseTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CourseDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PreValidDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ValidationDate { get; set; }
        public long? ApprovalStatusId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? Approvedby { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public string DocumentFilePath { get; set; }
        public string DocumentContentType { get; set; }
        public string Remarks { get; set; }

        [ForeignKey(nameof(ApprovalStatusId))]
        [InverseProperty("UserStandards")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        [ForeignKey(nameof(Approvedby))]
        [InverseProperty(nameof(SecUser.UserStandardsApprovedbyNavigation))]
        public virtual SecUser ApprovedbyNavigation { get; set; }
        [ForeignKey(nameof(AuditorTypeId))]
        [InverseProperty(nameof(AuditorTypes.UserStandards))]
        public virtual AuditorTypes AuditorType { get; set; }
        [ForeignKey(nameof(CourseTypeId))]
        [InverseProperty("UserStandards")]
        public virtual CourseType CourseType { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.UserStandardsCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.UserStandardsLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.UserStandards))]
        public virtual Certification Standard { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserStandardsUser))]
        public virtual SecUser User { get; set; }
    }
}
