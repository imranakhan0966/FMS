using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class AuditorTypes
    {
        public AuditorTypes()
        {
            UserStandards = new HashSet<UserStandards>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public long? UserLevel { get; set; }

        [InverseProperty("AuditorType")]
        public virtual ICollection<UserStandards> UserStandards { get; set; }
    }
}
