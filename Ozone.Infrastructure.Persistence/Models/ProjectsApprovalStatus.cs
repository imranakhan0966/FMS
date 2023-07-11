using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ProjectsApprovalStatus
    {
        public ProjectsApprovalStatus()
        {
            ClientProjects = new HashSet<ClientProjects>();
            ProjectRemarksHistory = new HashSet<ProjectRemarksHistory>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(SecRole.ProjectsApprovalStatus))]
        public virtual SecRole Role { get; set; }
        [InverseProperty("ApprovalStatus")]
        public virtual ICollection<ClientProjects> ClientProjects { get; set; }
        [InverseProperty("ApprovalStatus")]
        public virtual ICollection<ProjectRemarksHistory> ProjectRemarksHistory { get; set; }
    }
}
