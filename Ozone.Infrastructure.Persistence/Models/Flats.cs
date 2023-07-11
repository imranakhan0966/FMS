using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Flats
    {
        public Flats()
        {
            SecUser = new HashSet<SecUser>();
            ServiceRequest = new HashSet<ServiceRequest>();
        }

        [Key]
        [Sieve(CanFilter = true)]
        public long Id { get; set; }
        [StringLength(15)]
        [Sieve(CanFilter = true)]
        public string Code { get; set; }
        [StringLength(500)]
        [Sieve(CanFilter = true)]
        public string Name { get; set; }
        [Sieve(CanFilter = true)]
        public long? ParkingSlotId { get; set; }
        [Sieve(CanFilter = true)]
        public long? FloorId { get; set; }
        [Sieve(CanFilter = true)]
        public long? BuildingId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        [Sieve(CanFilter = true)]
        public bool? IsAllotted { get; set; }

        [ForeignKey(nameof(BuildingId))]
        [InverseProperty(nameof(Buildings.Flats))]
        public virtual Buildings Building { get; set; }
        [ForeignKey(nameof(FloorId))]
        [InverseProperty(nameof(Floors.Flats))]
        public virtual Floors Floor { get; set; }
        [ForeignKey(nameof(ParkingSlotId))]
        [InverseProperty(nameof(ParkingSlots.Flats))]
        public virtual ParkingSlots ParkingSlot { get; set; }
        [InverseProperty("Flat")]
        public virtual ICollection<SecUser> SecUser { get; set; }
        [InverseProperty("Flat")]
        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
