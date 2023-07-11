using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class HolidayCalendar
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public long? OrganizationId { get; set; }
        public long? HolidayTypeId { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.HolidayCalendarCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(HolidayTypeId))]
        [InverseProperty("HolidayCalendar")]
        public virtual HolidayType HolidayType { get; set; }
        [ForeignKey(nameof(LastModifiedBy))]
        [InverseProperty(nameof(SecUser.HolidayCalendarLastModifiedByNavigation))]
        public virtual SecUser LastModifiedByNavigation { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("HolidayCalendar")]
        public virtual Organization Organization { get; set; }
    }
}
