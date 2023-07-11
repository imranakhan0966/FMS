using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    [Table("ProjectSLCP")]
    public partial class ProjectSlcp
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
        public long? CompletedStepId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TentativeDate { get; set; }
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
        public long? AccreditationId { get; set; }

        [ForeignKey(nameof(AccreditationId))]
        [InverseProperty("ProjectSlcp")]
        public virtual Accreditation Accreditation { get; set; }
        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(SecUser.ProjectSlcpApprovedBy))]
        public virtual SecUser ApprovedBy { get; set; }
        [ForeignKey(nameof(AssessmentCompletedId))]
        [InverseProperty("ProjectSlcp")]
        public virtual AssessmentCompleted AssessmentCompleted { get; set; }
        [ForeignKey(nameof(ClientProjectId))]
        [InverseProperty(nameof(ClientProjects.ProjectSlcp))]
        public virtual ClientProjects ClientProject { get; set; }
        [ForeignKey(nameof(CompletedStepId))]
        [InverseProperty(nameof(CompletedSteps.ProjectSlcp))]
        public virtual CompletedSteps CompletedStep { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ProjectSlcpCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ProjectSlcpLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(MethodologyId))]
        [InverseProperty("ProjectSlcp")]
        public virtual Methodology Methodology { get; set; }
        [ForeignKey(nameof(ModuleShareId))]
        [InverseProperty("ProjectSlcp")]
        public virtual ModuleShare ModuleShare { get; set; }
        [ForeignKey(nameof(ModuleVersionId))]
        [InverseProperty("ProjectSlcp")]
        public virtual ModuleVersion ModuleVersion { get; set; }
        [ForeignKey(nameof(RequestOfSiteId))]
        [InverseProperty("ProjectSlcp")]
        public virtual RequestOfSite RequestOfSite { get; set; }
        [ForeignKey(nameof(ServicesTypeId))]
        [InverseProperty(nameof(ServiceType.ProjectSlcp))]
        public virtual ServiceType ServicesType { get; set; }
    }
}
