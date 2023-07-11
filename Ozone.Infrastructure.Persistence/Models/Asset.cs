using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Asset
    {
        [Key]
        public long Id { get; set; }
        [Column("code")]
        public int? Code { get; set; }
        [Column("name")]
        [StringLength(500)]
        public string Name { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("create_user")]
        public int? CreateUser { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long? BuildingId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        [InverseProperty(nameof(Buildings.Asset))]
        public virtual Buildings Building { get; set; }
    }
}
