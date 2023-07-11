using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class HolidayType
    {
        public HolidayType()
        {
            HolidayCalendar = new HashSet<HolidayCalendar>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }

        [InverseProperty("HolidayType")]
        public virtual ICollection<HolidayCalendar> HolidayCalendar { get; set; }
    }
}
