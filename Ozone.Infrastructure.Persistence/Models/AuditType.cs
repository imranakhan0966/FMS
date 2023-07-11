using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class AuditType
    {
        public AuditType()
        {
            UserAudit = new HashSet<UserAudit>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(25)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [InverseProperty("AuditType")]
        public virtual ICollection<UserAudit> UserAudit { get; set; }
    }
}
