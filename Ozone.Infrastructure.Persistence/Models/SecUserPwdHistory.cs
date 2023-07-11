using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class SecUserPwdHistory
    {
        [Key]
        public long Id { get; set; }
        public long SecUserId { get; set; }
        [StringLength(50)]
        public string SecurityKey { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public bool IsClosed { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(SecUserId))]
        [InverseProperty("SecUserPwdHistory")]
        public virtual SecUser SecUser { get; set; }
    }
}
