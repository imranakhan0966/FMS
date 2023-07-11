using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class OrgCertification
    {
        [Key]
        public long Id { get; set; }
        public long? AgencyId { get; set; }
        public long? CertificationId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? AuthorizedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AuthorizedDate { get; set; }
        public bool? IsSubmitted { get; set; }
        public bool? IsAuthorized { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(AgencyId))]
        [InverseProperty(nameof(Organization.OrgCertification))]
        public virtual Organization Agency { get; set; }
        [ForeignKey(nameof(CertificationId))]
        [InverseProperty("OrgCertification")]
        public virtual Certification Certification { get; set; }
    }
}
