using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class CompletedSteps
    {
        public CompletedSteps()
        {
            ProjectSlcp = new HashSet<ProjectSlcp>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreeatedDate { get; set; }
        public string Description { get; set; }

        [InverseProperty("CompletedStep")]
        public virtual ICollection<ProjectSlcp> ProjectSlcp { get; set; }
    }
}
