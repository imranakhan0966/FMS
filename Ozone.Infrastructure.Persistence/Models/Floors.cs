using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Floors
    {
        public Floors()
        {
            Flats = new HashSet<Flats>();
            ParkingSlots = new HashSet<ParkingSlots>();
            SecUser = new HashSet<SecUser>();
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
        public long? FloorTypeId { get; set; }
        [Sieve(CanFilter = true)]
        public long? BuildingId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(BuildingId))]
        [InverseProperty(nameof(Buildings.Floors))]
        public virtual Buildings Building { get; set; }
        [ForeignKey(nameof(FloorTypeId))]
        [InverseProperty("Floors")]
        public virtual FloorType FloorType { get; set; }
        [InverseProperty("Floor")]
        public virtual ICollection<Flats> Flats { get; set; }
        [InverseProperty("Floor")]
        public virtual ICollection<ParkingSlots> ParkingSlots { get; set; }
        [InverseProperty("Floor")]
        public virtual ICollection<SecUser> SecUser { get; set; }
    }
}
