using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class WorkProgressHistory
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Commemts { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CommemtsDate { get; set; }
        public long? ServiceId { get; set; }
    }
}
