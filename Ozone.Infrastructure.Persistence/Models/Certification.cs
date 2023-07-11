using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Certification
    {
        public Certification()
        {
            ClientProjects = new HashSet<ClientProjects>();
            Library = new HashSet<Library>();
            ModuleVersion = new HashSet<ModuleVersion>();
            OrgCertification = new HashSet<OrgCertification>();
            ProjectAmount = new HashSet<ProjectAmount>();
            ProjectFormsPath = new HashSet<ProjectFormsPath>();
            QcdocumentsList = new HashSet<QcdocumentsList>();
            StageOfCertification = new HashSet<StageOfCertification>();
            UserAudit = new HashSet<UserAudit>();
            UserAuditorNace = new HashSet<UserAuditorNace>();
            UserConsultancy = new HashSet<UserConsultancy>();
            UserCpd = new HashSet<UserCpd>();
            UserStandards = new HashSet<UserStandards>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [InverseProperty("Standard")]
        public virtual ICollection<ClientProjects> ClientProjects { get; set; }
        [InverseProperty("Certification")]
        public virtual ICollection<Library> Library { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<ModuleVersion> ModuleVersion { get; set; }
        [InverseProperty("Certification")]
        public virtual ICollection<OrgCertification> OrgCertification { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<ProjectAmount> ProjectAmount { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<ProjectFormsPath> ProjectFormsPath { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<QcdocumentsList> QcdocumentsList { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<StageOfCertification> StageOfCertification { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<UserAudit> UserAudit { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<UserAuditorNace> UserAuditorNace { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<UserConsultancy> UserConsultancy { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<UserCpd> UserCpd { get; set; }
        [InverseProperty("Standard")]
        public virtual ICollection<UserStandards> UserStandards { get; set; }
    }
}
