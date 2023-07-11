using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class QcStatus
    {
        public QcStatus()
        {
            QcMasterComments = new HashSet<QcMasterComments>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [InverseProperty("QcStatus")]
        public virtual ICollection<QcMasterComments> QcMasterComments { get; set; }
    }
}
