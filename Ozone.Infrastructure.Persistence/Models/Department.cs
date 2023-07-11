using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Department
    {
        public Department()
        {
            SecUser = new HashSet<SecUser>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsClosed { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<SecUser> SecUser { get; set; }
    }
}
