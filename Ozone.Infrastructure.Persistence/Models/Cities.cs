using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Buildings = new HashSet<Buildings>();
            Client = new HashSet<Client>();
            ClientSites = new HashSet<ClientSites>();
            Consultant = new HashSet<Consultant>();
            Organization = new HashSet<Organization>();
            SecUser = new HashSet<SecUser>();
        }

        [Key]
        [Sieve(CanFilter = true)]
        public long Id { get; set; }
        [StringLength(15)]
        public string Code { get; set; }
        [StringLength(500)]
        [Sieve(CanFilter = true)]
        public string Name { get; set; }
        [Sieve(CanFilter = true)]
        public long? StateId { get; set; }
        [Sieve(CanFilter = true)]
        public long? CountryId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.Cities))]
        public virtual Countries Country { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Cities")]
        public virtual State State { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Buildings> Buildings { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Client> Client { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<ClientSites> ClientSites { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Consultant> Consultant { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Organization> Organization { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<SecUser> SecUser { get; set; }
    }
}
