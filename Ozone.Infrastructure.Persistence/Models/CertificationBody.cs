using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class CertificationBody
    {
        public CertificationBody()
        {
            UserAudit = new HashSet<UserAudit>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(25)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Body { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.CertificationBodyCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(LastModifiedy))]
        [InverseProperty(nameof(SecUser.CertificationBodyLastModifiedyNavigation))]
        public virtual SecUser LastModifiedyNavigation { get; set; }
        [InverseProperty("CertificationBody")]
        public virtual ICollection<UserAudit> UserAudit { get; set; }
    }
}
