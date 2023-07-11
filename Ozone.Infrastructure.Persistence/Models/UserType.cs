using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class UserType
    {
        public UserType()
        {
            SecUser = new HashSet<SecUser>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(15)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public int? UserLevel { get; set; }

        [InverseProperty("UserType")]
        public virtual ICollection<SecUser> SecUser { get; set; }
    }
}
