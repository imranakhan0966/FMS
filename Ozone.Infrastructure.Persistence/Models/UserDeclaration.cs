using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserDeclaration
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        [StringLength(200)]
        public string CompanyName { get; set; }
        public long? ContractTypeId { get; set; }
        [StringLength(200)]
        public string Interest { get; set; }
        public long? ApprovalStatusId { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(ApprovalStatusId))]
        [InverseProperty("UserDeclaration")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        [ForeignKey(nameof(ApprovedBy))]
        [InverseProperty(nameof(SecUser.UserDeclarationApprovedByNavigation))]
        public virtual SecUser ApprovedByNavigation { get; set; }
        [ForeignKey(nameof(ContractTypeId))]
        [InverseProperty("UserDeclaration")]
        public virtual ContractType ContractType { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.UserDeclarationCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(SecUser.UserDeclarationUser))]
        public virtual SecUser User { get; set; }
    }
}
