using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class SecRoleForm
    {
        [Key]
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public bool InsertAllowed { get; set; }
        public bool UpdateAllowed { get; set; }
        public bool QueryAllowed { get; set; }
        public bool AuthAllowed { get; set; }
        public bool IsClosed { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [Required]
        public bool? SbpAllowed { get; set; }
        public bool? ManageAllowed { get; set; }
        public bool? DeleteAllowed { get; set; }
        public bool? ViewRecordAllowed { get; set; }

        [ForeignKey(nameof(PermissionId))]
        [InverseProperty(nameof(SecForm.SecRoleForm))]
        public virtual SecForm Permission { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(SecRole.SecRoleForm))]
        public virtual SecRole Role { get; set; }
    }
}
