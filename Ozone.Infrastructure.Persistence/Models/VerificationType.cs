using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class VerificationType
    {
        public VerificationType()
        {
            ClientProjects = new HashSet<ClientProjects>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastUpdatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdatedDate { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.VerificationTypeCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastUpdatedById))]
        [InverseProperty(nameof(SecUser.VerificationTypeLastUpdatedBy))]
        public virtual SecUser LastUpdatedBy { get; set; }
        [InverseProperty("VerificationType")]
        public virtual ICollection<ClientProjects> ClientProjects { get; set; }
    }
}
