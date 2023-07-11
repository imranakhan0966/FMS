using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Prifix
    {
        public Prifix()
        {
            Client = new HashSet<Client>();
            Consultant = new HashSet<Consultant>();
            SecUser = new HashSet<SecUser>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty("Prefix")]
        public virtual ICollection<Client> Client { get; set; }
        [InverseProperty("Prefix")]
        public virtual ICollection<Consultant> Consultant { get; set; }
        [InverseProperty("Prefix")]
        public virtual ICollection<SecUser> SecUser { get; set; }
    }
}
