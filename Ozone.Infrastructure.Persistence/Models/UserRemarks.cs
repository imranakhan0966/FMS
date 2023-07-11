using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserRemarks
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string Remarks { get; set; }
        public long? RemarksById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RemarksDate { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(ApprovalStatusId))]
        [InverseProperty("UserRemarks")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        [ForeignKey(nameof(RemarksById))]
        [InverseProperty(nameof(SecUser.UserRemarksRemarksBy))]
        public virtual SecUser RemarksBy { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserRemarksUser))]
        public virtual SecUser User { get; set; }
    }
}
