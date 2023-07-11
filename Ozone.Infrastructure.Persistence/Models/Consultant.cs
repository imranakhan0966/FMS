using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Consultant
    {
        public Consultant()
        {
            ProjectSa8000 = new HashSet<ProjectSa8000>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string TellNumber { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        public long? CountryId { get; set; }
        public long? CityId { get; set; }
        public long? StateId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdatedDate { get; set; }
        public long? LastUpdatedId { get; set; }
        public long? OrganizationId { get; set; }
        public long? PrefixId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Cities.Consultant))]
        public virtual Cities City { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.Consultant))]
        public virtual Countries Country { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ConsultantCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastUpdatedId))]
        [InverseProperty(nameof(SecUser.ConsultantLastUpdated))]
        public virtual SecUser LastUpdated { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("Consultant")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(PrefixId))]
        [InverseProperty(nameof(Prifix.Consultant))]
        public virtual Prifix Prefix { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Consultant")]
        public virtual State State { get; set; }
        [InverseProperty("Consultant")]
        public virtual ICollection<ProjectSa8000> ProjectSa8000 { get; set; }
    }
}
