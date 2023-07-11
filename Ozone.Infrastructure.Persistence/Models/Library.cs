using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Library
    {
        [Key]
        public long Id { get; set; }
        [StringLength(25)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Version { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        public long? Reviewer { get; set; }
        public long? ModuleId { get; set; }
        public long? DocumentTypeId { get; set; }
        public long? StatusId { get; set; }
        public long? CertificationId { get; set; }
        public long? AuthorizedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AuthorizedDate { get; set; }
        public bool? IsSubmitted { get; set; }
        public bool? IsAuthorized { get; set; }
        [StringLength(500)]
        public string Remarks { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public long? OrganizationId { get; set; }

        [ForeignKey(nameof(CertificationId))]
        [InverseProperty("Library")]
        public virtual Certification Certification { get; set; }
        [ForeignKey(nameof(DocumentTypeId))]
        [InverseProperty("Library")]
        public virtual DocumentType DocumentType { get; set; }
        [ForeignKey(nameof(ModuleId))]
        [InverseProperty("Library")]
        public virtual Module Module { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("Library")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(Reviewer))]
        [InverseProperty(nameof(SecUser.Library))]
        public virtual SecUser ReviewerNavigation { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty("Library")]
        public virtual Status Status { get; set; }
    }
}
