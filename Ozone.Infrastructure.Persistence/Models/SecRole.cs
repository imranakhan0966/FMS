using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class SecRole
    {
        public SecRole()
        {
            ProjectsApprovalStatus = new HashSet<ProjectsApprovalStatus>();
            SecRoleForm = new HashSet<SecRoleForm>();
            SecUser = new HashSet<SecUser>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public long RoleType { get; set; }
        public bool IsClosed { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long? AuthorizedBy { get; set; }
        public DateTime? AuthorizedDate { get; set; }
        public bool IsSubmitted { get; set; }
        public bool? IsAuthorized { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }
        public int? UserLevel { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<ProjectsApprovalStatus> ProjectsApprovalStatus { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<SecRoleForm> SecRoleForm { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<SecUser> SecUser { get; set; }
    }
}
