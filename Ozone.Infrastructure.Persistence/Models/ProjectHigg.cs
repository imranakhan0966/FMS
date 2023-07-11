using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ProjectHigg
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public long? ClientProjectId { get; set; }
        public long? ServicesTypeId { get; set; }
        public long? MethodologyId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FromDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ToDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApplicationDate { get; set; }
        public long? AssessmentCompletedId { get; set; }
        public long? CompletedModuleId { get; set; }
        public string ManufacturingProcessess { get; set; }
        public long? EffluentTreatmentPlantId { get; set; }
        public long? NoOfMd { get; set; }
        public long? ModuleVersionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BodySelectDate { get; set; }
        public long? ModuleShareId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WindowPeriodDate { get; set; }
        public long? ModuleYear { get; set; }
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
        public long? RequestOfSiteId { get; set; }

        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(SecUser.ProjectHiggApprovedBy))]
        public virtual SecUser ApprovedBy { get; set; }
        [ForeignKey(nameof(AssessmentCompletedId))]
        [InverseProperty("ProjectHigg")]
        public virtual AssessmentCompleted AssessmentCompleted { get; set; }
        [ForeignKey(nameof(ClientProjectId))]
        [InverseProperty(nameof(ClientProjects.ProjectHigg))]
        public virtual ClientProjects ClientProject { get; set; }
        [ForeignKey(nameof(CompletedModuleId))]
        [InverseProperty("ProjectHigg")]
        public virtual CompletedModule CompletedModule { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ProjectHiggCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(EffluentTreatmentPlantId))]
        [InverseProperty("ProjectHigg")]
        public virtual EffluentTreatmentPlant EffluentTreatmentPlant { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ProjectHiggLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(MethodologyId))]
        [InverseProperty("ProjectHigg")]
        public virtual Methodology Methodology { get; set; }
        [ForeignKey(nameof(ModuleShareId))]
        [InverseProperty("ProjectHigg")]
        public virtual ModuleShare ModuleShare { get; set; }
        [ForeignKey(nameof(ModuleVersionId))]
        [InverseProperty("ProjectHigg")]
        public virtual ModuleVersion ModuleVersion { get; set; }
        [ForeignKey(nameof(RequestOfSiteId))]
        [InverseProperty("ProjectHigg")]
        public virtual RequestOfSite RequestOfSite { get; set; }
        [ForeignKey(nameof(ServicesTypeId))]
        [InverseProperty(nameof(ServiceType.ProjectHigg))]
        public virtual ServiceType ServicesType { get; set; }
    }
}
