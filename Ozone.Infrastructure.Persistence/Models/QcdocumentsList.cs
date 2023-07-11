using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    [Table("QCDocumentsList")]
    public partial class QcdocumentsList
    {
        public QcdocumentsList()
        {
            QcHistory = new HashSet<QcHistory>();
            QcMasterComments = new HashSet<QcMasterComments>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(25)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? OrganizationId { get; set; }
        public long? StandardId { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("QcdocumentsList")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.QcdocumentsList))]
        public virtual Certification Standard { get; set; }
        [InverseProperty("QcdocumentsList")]
        public virtual ICollection<QcHistory> QcHistory { get; set; }
        [InverseProperty("QcDocuments")]
        public virtual ICollection<QcMasterComments> QcMasterComments { get; set; }
    }
}
