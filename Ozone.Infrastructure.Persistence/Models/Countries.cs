using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Buildings = new HashSet<Buildings>();
            Cities = new HashSet<Cities>();
            Client = new HashSet<Client>();
            ClientSites = new HashSet<ClientSites>();
            Consultant = new HashSet<Consultant>();
            Legislation = new HashSet<Legislation>();
            Organization = new HashSet<Organization>();
            SecUser = new HashSet<SecUser>();
            State = new HashSet<State>();
        }

        [Key]
        [Sieve(CanFilter = true)]
        public long Id { get; set; }
        [Column("code")]
        public int? Code { get; set; }
        [Column("name")]
        [StringLength(500)]
        [Sieve(CanFilter = true)]
        public string Name { get; set; }
        [Column("status")]
        [Sieve(CanFilter = true)]
        public int? Status { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("create_user")]
        [Sieve(CanFilter = true)]
        public int? CreateUser { get; set; }
        [Column("create_unit")]
        [StringLength(200)]
        public string CreateUnit { get; set; }
        [Column("approved1")]
        public int? Approved1 { get; set; }
        [Column("approved2")]
        public int? Approved2 { get; set; }
        [Column("post")]
        public int? Post { get; set; }
        [Column("approved1_user")]
        public int? Approved1User { get; set; }
        [Column("approved2_user")]
        public int? Approved2User { get; set; }
        [Column("post_user")]
        public int? PostUser { get; set; }
        [Column("rb_user")]
        public int? RbUser { get; set; }
        [Column("ae_user")]
        public int? AeUser { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<Buildings> Buildings { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<Cities> Cities { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<Client> Client { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<ClientSites> ClientSites { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<Consultant> Consultant { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<Legislation> Legislation { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<Organization> Organization { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<SecUser> SecUser { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<State> State { get; set; }
    }
}
