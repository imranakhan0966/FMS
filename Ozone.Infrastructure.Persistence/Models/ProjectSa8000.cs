using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    [Table("Project_SA8000")]
    public partial class ProjectSa8000
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public long? ClientProjectId { get; set; }
        public long? RiskId { get; set; }
        [Column("EACodeId")]
        public long? EacodeId { get; set; }
        public long? NaceCodeId { get; set; }
        public long? ConsultantId { get; set; }
        public long? AccreditationId { get; set; }
        public string Scope { get; set; }
        [StringLength(100)]
        public string PreAuditDuration { get; set; }
        [StringLength(100)]
        public string DurationStage1 { get; set; }
        [StringLength(100)]
        public string DurationStage2 { get; set; }
        public long? SurveillanceVisitFrequencyId { get; set; }
        public long? SurveillanceMethodId { get; set; }
        [StringLength(200)]
        public string NoOfSurveillanceVisits { get; set; }
        public double? Applicatonfee { get; set; }
        public double? PreAuditfee { get; set; }
        public double? Assessmentfee { get; set; }
        public double? Survfee { get; set; }
        public long? ExpensesId { get; set; }
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

        [ForeignKey(nameof(AccreditationId))]
        [InverseProperty("ProjectSa8000")]
        public virtual Accreditation Accreditation { get; set; }
        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(SecUser.ProjectSa8000ApprovedBy))]
        public virtual SecUser ApprovedBy { get; set; }
        [ForeignKey(nameof(ClientProjectId))]
        [InverseProperty(nameof(ClientProjects.ProjectSa8000))]
        public virtual ClientProjects ClientProject { get; set; }
        [ForeignKey(nameof(ConsultantId))]
        [InverseProperty("ProjectSa8000")]
        public virtual Consultant Consultant { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ProjectSa8000CreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(EacodeId))]
        [InverseProperty("ProjectSa8000")]
        public virtual Eacode Eacode { get; set; }
        [ForeignKey(nameof(ExpensesId))]
        [InverseProperty("ProjectSa8000")]
        public virtual Expenses Expenses { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ProjectSa8000LastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(NaceCodeId))]
        [InverseProperty("ProjectSa8000")]
        public virtual NaceCode NaceCode { get; set; }
        [ForeignKey(nameof(RiskId))]
        [InverseProperty("ProjectSa8000")]
        public virtual Risk Risk { get; set; }
        [ForeignKey(nameof(SurveillanceMethodId))]
        [InverseProperty("ProjectSa8000")]
        public virtual SurveillanceMethod SurveillanceMethod { get; set; }
        [ForeignKey(nameof(SurveillanceVisitFrequencyId))]
        [InverseProperty("ProjectSa8000")]
        public virtual SurveillanceVisitFrequency SurveillanceVisitFrequency { get; set; }
    }
}
