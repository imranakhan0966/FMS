using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Library = new HashSet<Library>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleteed { get; set; }
        [StringLength(25)]
        public string Code { get; set; }
        public string Description { get; set; }

        [InverseProperty("DocumentType")]
        public virtual ICollection<Library> Library { get; set; }
    }
}
