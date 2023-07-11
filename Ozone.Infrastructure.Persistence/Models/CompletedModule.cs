using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class CompletedModule
    {
        public CompletedModule()
        {
            ProjectHigg = new HashSet<ProjectHigg>();
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
        [InverseProperty(nameof(SecUser.CompletedModuleCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.CompletedModuleLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [InverseProperty("CompletedModule")]
        public virtual ICollection<ProjectHigg> ProjectHigg { get; set; }
    }
}
