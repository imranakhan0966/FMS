using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Client
    {
        public Client()
        {
            Buildings = new HashSet<Buildings>();
            ClientProjects = new HashSet<ClientProjects>();
            ClientSites = new HashSet<ClientSites>();
            ServiceRequest = new HashSet<ServiceRequest>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(15)]
        public string Code { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        [StringLength(25)]
        public string MobileNumber { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public long? OrganizationId { get; set; }
        [StringLength(100)]
        public string ContactPerson { get; set; }
        [StringLength(25)]
        public string PersonContactNumber { get; set; }
        [Required]
        [StringLength(200)]
        public string Address1 { get; set; }
        [StringLength(200)]
        public string Address2 { get; set; }
        [Sieve(CanFilter = true)]
        public long? CountryId { get; set; }
        [Sieve(CanFilter = true)]
        public long? CityId { get; set; }
        [StringLength(25)]
        public string PostalCode { get; set; }
        public long? PrefixId { get; set; }
        public string Position { get; set; }
        public bool? IsActive { get; set; }
        public bool? Multisite { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        [Sieve(CanFilter = true)]
        public long? StateId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Cities.Client))]
        public virtual Cities City { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.Client))]
        public virtual Countries Country { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("Client")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(PrefixId))]
        [InverseProperty(nameof(Prifix.Client))]
        public virtual Prifix Prefix { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Client")]
        public virtual State State { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Buildings> Buildings { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<ClientProjects> ClientProjects { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<ClientSites> ClientSites { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
