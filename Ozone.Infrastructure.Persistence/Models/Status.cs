using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Status
    {
        public Status()
        {
            Library = new HashSet<Library>();
            ServiceRequest = new HashSet<ServiceRequest>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<Library> Library { get; set; }
        [InverseProperty("Status")]
        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
