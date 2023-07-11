using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Buildings
    {
        public Buildings()
        {
            Asset = new HashSet<Asset>();
            Flats = new HashSet<Flats>();
            Floors = new HashSet<Floors>();
            ParkingSlots = new HashSet<ParkingSlots>();
            SecUser = new HashSet<SecUser>();
            ServiceRequest = new HashSet<ServiceRequest>();
        }

        [Key]
        [Sieve(CanFilter = true)]
        public long Id { get; set; }
        [Column("code")]
        public int? Code { get; set; }
        [Column("name")]
        [Sieve(CanFilter = true)]
        [StringLength(500)]
        public string Name { get; set; }
        [Sieve(CanFilter = true)]
        public long? CountryId { get; set; }
        [Sieve(CanFilter = true)]
        public long? StateId { get; set; }
        [Sieve(CanFilter = true)]
        public long? CityId { get; set; }
        [Sieve(CanFilter = true)]
        public long? ClientId { get; set; }
        [Sieve(CanFilter = true)]
        public int? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        [StringLength(10)]
        public string FloorPrefix { get; set; }
        [StringLength(10)]
        public string FloorParkingPrefix { get; set; }
        [StringLength(10)]
        public string FlatPrefix { get; set; }
        [StringLength(10)]
        public string ParkingPrefix { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Cities.Buildings))]
        public virtual Cities City { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Buildings")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.Buildings))]
        public virtual Countries Country { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Buildings")]
        public virtual State State { get; set; }
        [InverseProperty("Building")]
        public virtual ICollection<Asset> Asset { get; set; }
        [InverseProperty("Building")]
        public virtual ICollection<Flats> Flats { get; set; }
        [InverseProperty("Building")]
        public virtual ICollection<Floors> Floors { get; set; }
        [InverseProperty("Building")]
        public virtual ICollection<ParkingSlots> ParkingSlots { get; set; }
        [InverseProperty("Building")]
        public virtual ICollection<SecUser> SecUser { get; set; }
        [InverseProperty("Building")]
        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
