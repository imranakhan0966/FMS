using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class OrganizationType
    {
        public OrganizationType()
        {
            Organization = new HashSet<Organization>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(25)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty("OrganizationType")]
        public virtual ICollection<Organization> Organization { get; set; }
    }
}
