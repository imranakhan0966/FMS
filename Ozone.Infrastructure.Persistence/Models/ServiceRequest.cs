using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ServiceRequest
    {
        [Key]
        [Sieve(CanFilter = true)]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(100)]
        [Sieve(CanFilter = true)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Sieve(CanFilter = true)]
        public long? ServiceTypeId { get; set; }
        public long? ClientId { get; set; }
        [Sieve(CanFilter = true)]
        public long? BuildingId { get; set; }
        [Sieve(CanFilter = true)]
        public long? FlatId { get; set; }
        [StringLength(256)]
        [Sieve(CanFilter = true)]
        public string Asset { get; set; }
        [Sieve(CanFilter = true)]
        public long? PriorityId { get; set; }
        public string MaintainerComments { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        [Sieve(CanFilter = true)]
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public long? CompletedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompletedDate { get; set; }
        [Sieve(CanFilter = true)]
        public long? StatusId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        [InverseProperty(nameof(Buildings.ServiceRequest))]
        public virtual Buildings Building { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ServiceRequest")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(FlatId))]
        [InverseProperty(nameof(Flats.ServiceRequest))]
        public virtual Flats Flat { get; set; }
        [ForeignKey(nameof(PriorityId))]
        [InverseProperty("ServiceRequest")]
        public virtual Priority Priority { get; set; }
        [ForeignKey(nameof(ServiceTypeId))]
        [InverseProperty("ServiceRequest")]
        public virtual ServiceType ServiceType { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty("ServiceRequest")]
        public virtual Status Status { get; set; }
    }
}
