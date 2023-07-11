using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Accreditation
    {
        public Accreditation()
        {
            ProjectIso = new HashSet<ProjectIso>();
            ProjectSa8000 = new HashSet<ProjectSa8000>();
            ProjectSlcp = new HashSet<ProjectSlcp>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.AccreditationCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.AccreditationLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [InverseProperty("AccreditationNavigation")]
        public virtual ICollection<ProjectIso> ProjectIso { get; set; }
        [InverseProperty("Accreditation")]
        public virtual ICollection<ProjectSa8000> ProjectSa8000 { get; set; }
        [InverseProperty("Accreditation")]
        public virtual ICollection<ProjectSlcp> ProjectSlcp { get; set; }
    }
}
