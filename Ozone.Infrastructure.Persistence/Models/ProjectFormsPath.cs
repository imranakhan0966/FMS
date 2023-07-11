using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ProjectFormsPath
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public string Name { get; set; }
        public long? StandardId { get; set; }
        public string Path { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeletes { get; set; }

        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.ProjectFormsPath))]
        public virtual Certification Standard { get; set; }
    }
}
