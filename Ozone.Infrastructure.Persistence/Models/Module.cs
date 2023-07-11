using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Module
    {
        public Module()
        {
            Library = new HashSet<Library>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        [StringLength(25)]
        public string Code { get; set; }
        public bool? IsDeleted { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [InverseProperty("Module")]
        public virtual ICollection<Library> Library { get; set; }
    }
}
