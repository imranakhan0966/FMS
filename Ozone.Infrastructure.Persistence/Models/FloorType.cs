using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class FloorType
    {
        public FloorType()
        {
            Floors = new HashSet<Floors>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty("FloorType")]
        public virtual ICollection<Floors> Floors { get; set; }
    }
}
