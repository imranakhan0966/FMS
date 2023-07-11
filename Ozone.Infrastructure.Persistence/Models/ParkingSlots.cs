using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ParkingSlots
    {
        public ParkingSlots()
        {
            Flats = new HashSet<Flats>();
        }

        [Key]
        [Sieve(CanFilter = true)]
        public long Id { get; set; }
        [StringLength(50)]
        [Sieve(CanFilter = true)]
        public string Code { get; set; }
        [StringLength(100)]
        [Sieve(CanFilter = true)]
        public string Name { get; set; }
        [Sieve(CanFilter = true)]
        public long? FloorId { get; set; }
        [Sieve(CanFilter = true)]
        public long? BuildingId { get; set; }
        [Column("isAllotted")]
        [Sieve(CanFilter = true)]
        public bool? IsAllotted { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDeleted")]
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(BuildingId))]
        [InverseProperty(nameof(Buildings.ParkingSlots))]
        public virtual Buildings Building { get; set; }
        [ForeignKey(nameof(FloorId))]
        [InverseProperty(nameof(Floors.ParkingSlots))]
        public virtual Floors Floor { get; set; }
        [InverseProperty("ParkingSlot")]
        public virtual ICollection<Flats> Flats { get; set; }
    }
}
