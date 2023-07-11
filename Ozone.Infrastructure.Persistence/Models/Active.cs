using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Active
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}
