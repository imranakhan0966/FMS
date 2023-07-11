using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ProjectRemarksHistory
    {
        [Key]
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string Remarks { get; set; }
        public long? RemarksById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RemarksDate { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(ApprovalStatusId))]
        [InverseProperty(nameof(ProjectsApprovalStatus.ProjectRemarksHistory))]
        public virtual ProjectsApprovalStatus ApprovalStatus { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(ClientProjects.ProjectRemarksHistory))]
        public virtual ClientProjects Project { get; set; }
        [ForeignKey(nameof(RemarksById))]
        [InverseProperty(nameof(SecUser.ProjectRemarksHistory))]
        public virtual SecUser RemarksBy { get; set; }
    }
}
