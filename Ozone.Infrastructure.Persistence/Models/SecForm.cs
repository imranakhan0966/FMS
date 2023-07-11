using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class SecForm
    {
        public SecForm()
        {
            ActivityLog = new HashSet<ActivityLog>();
            SecRoleForm = new HashSet<SecRoleForm>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public long TypeId { get; set; }
        public long? ParentId { get; set; }
        public long? AuthorizedBy { get; set; }
        public DateTime? AuthorizedDate { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(50)]
        public string MainTableName { get; set; }
        [StringLength(250)]
        public string SupportingTableNames { get; set; }
        public bool IsClosed { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [InverseProperty("Form")]
        public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        [InverseProperty("Permission")]
        public virtual ICollection<SecRoleForm> SecRoleForm { get; set; }
    }
}
