using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    [Table("ProjectISO")]
    public partial class ProjectIso
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public long? ClientProjectId { get; set; }
        public long? AccreditationId { get; set; }
        public string BussinessScope { get; set; }
        public string TotalOccupancy { get; set; }
        public string NoOperationalShifts { get; set; }
        public long? NumberEmployees { get; set; }
        public long? NumberPartTimeEmployees { get; set; }
        public long? StageCertification { get; set; }
        public string Accreditation { get; set; }
        public string ScopeCodeEvaluation { get; set; }
        public string ApplicationFormPath { get; set; }
        public string ApplicationContentType { get; set; }
        public string Remarks { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApplicationDate { get; set; }

        [ForeignKey(nameof(AccreditationId))]
        [InverseProperty("ProjectIso")]
        public virtual Accreditation AccreditationNavigation { get; set; }
        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(SecUser.ProjectIsoApprovedBy))]
        public virtual SecUser ApprovedBy { get; set; }
        [ForeignKey(nameof(ClientProjectId))]
        [InverseProperty(nameof(ClientProjects.ProjectIso))]
        public virtual ClientProjects ClientProject { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ProjectIsoCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ProjectIsoLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(StageCertification))]
        [InverseProperty(nameof(StageOfCertification.ProjectIso))]
        public virtual StageOfCertification StageCertificationNavigation { get; set; }
    }
}
