using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Client = new HashSet<Client>();
            ClientAuditVisit = new HashSet<ClientAuditVisit>();
            Consultant = new HashSet<Consultant>();
            HolidayCalendar = new HashSet<HolidayCalendar>();
            Library = new HashSet<Library>();
            OrgCertification = new HashSet<OrgCertification>();
            ProjectAmount = new HashSet<ProjectAmount>();
            QcdocumentsList = new HashSet<QcdocumentsList>();
            ResetPasswordAccount = new HashSet<ResetPasswordAccount>();
            SecUser = new HashSet<SecUser>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(15)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(25)]
        public string ContactNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string ContactPerson { get; set; }
        [StringLength(25)]
        public string PersonContactNumber { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        public long? CountryId { get; set; }
        public long? CityId { get; set; }
        public long? OrganizationTypeId { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool? IsActive { get; set; }
        public long? StateId { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
        public string Address2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? JoiningDate { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Cities.Organization))]
        public virtual Cities City { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.Organization))]
        public virtual Countries Country { get; set; }
        [ForeignKey(nameof(OrganizationTypeId))]
        [InverseProperty("Organization")]
        public virtual OrganizationType OrganizationType { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Organization")]
        public virtual State State { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<Client> Client { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisit { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<Consultant> Consultant { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<HolidayCalendar> HolidayCalendar { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<Library> Library { get; set; }
        [InverseProperty("Agency")]
        public virtual ICollection<OrgCertification> OrgCertification { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<ProjectAmount> ProjectAmount { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<QcdocumentsList> QcdocumentsList { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<ResetPasswordAccount> ResetPasswordAccount { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<SecUser> SecUser { get; set; }
    }
}
