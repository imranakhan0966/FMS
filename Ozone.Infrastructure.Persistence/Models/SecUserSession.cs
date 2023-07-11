using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class SecUserSession
    {
        [Key]
        public long Id { get; set; }
        public long SecUserId { get; set; }
        public DateTime LoginDateTime { get; set; }
        public DateTime? LogoutDateTime { get; set; }
        [StringLength(25)]
        public string MachineId { get; set; }
        [Column("IPAddress")]
        [StringLength(15)]
        public string Ipaddress { get; set; }
        public bool IsClosed { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(SecUserId))]
        [InverseProperty("SecUserSession")]
        public virtual SecUser SecUser { get; set; }
    }
}
