using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ApprovalStatus
    {
        public ApprovalStatus()
        {
            AuditReportHistory = new HashSet<AuditReportHistory>();
            AuditReportMaster = new HashSet<AuditReportMaster>();
            SecUser = new HashSet<SecUser>();
            UserAuditorNace = new HashSet<UserAuditorNace>();
            UserDeclaration = new HashSet<UserDeclaration>();
            UserRemarks = new HashSet<UserRemarks>();
            UserStandards = new HashSet<UserStandards>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreeatedDate { get; set; }

        [InverseProperty("ApprovalStatus")]
        public virtual ICollection<AuditReportHistory> AuditReportHistory { get; set; }
        [InverseProperty("ApprovalStatus")]
        public virtual ICollection<AuditReportMaster> AuditReportMaster { get; set; }
        [InverseProperty("ApprovelStatus")]
        public virtual ICollection<SecUser> SecUser { get; set; }
        [InverseProperty("ApprovalStatus")]
        public virtual ICollection<UserAuditorNace> UserAuditorNace { get; set; }
        [InverseProperty("ApprovalStatus")]
        public virtual ICollection<UserDeclaration> UserDeclaration { get; set; }
        [InverseProperty("ApprovalStatus")]
        public virtual ICollection<UserRemarks> UserRemarks { get; set; }
        [InverseProperty("ApprovalStatus")]
        public virtual ICollection<UserStandards> UserStandards { get; set; }
    }
}
