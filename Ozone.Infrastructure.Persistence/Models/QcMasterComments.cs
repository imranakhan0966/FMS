using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class QcMasterComments
    {
        [Key]
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public long? QcDocumentsId { get; set; }
        public long? QcStatusId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long? ClientAuditVisitId { get; set; }

        [ForeignKey(nameof(ClientAuditVisitId))]
        [InverseProperty("QcMasterComments")]
        public virtual ClientAuditVisit ClientAuditVisit { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(ClientProjects.QcMasterComments))]
        public virtual ClientProjects Project { get; set; }
        [ForeignKey(nameof(QcDocumentsId))]
        [InverseProperty(nameof(QcdocumentsList.QcMasterComments))]
        public virtual QcdocumentsList QcDocuments { get; set; }
        [ForeignKey(nameof(QcStatusId))]
        [InverseProperty("QcMasterComments")]
        public virtual QcStatus QcStatus { get; set; }
    }
}
