using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ClientSites
    {
        public ClientSites()
        {
            ClientProjects = new HashSet<ClientProjects>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        public long ClientId { get; set; }
        [Required]
        public string SiteName { get; set; }
        [Column("legalStatus")]
        [StringLength(100)]
        public string LegalStatus { get; set; }
        public string OutsourceProductionProcessess { get; set; }
        public int? TotalEmployees { get; set; }
        public string ShiftTimings { get; set; }
        public string Address { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey(nameof(ApprovedById))]
        [InverseProperty(nameof(SecUser.ClientSitesApprovedBy))]
        public virtual SecUser ApprovedBy { get; set; }
        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Cities.ClientSites))]
        public virtual Cities City { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientSites")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.ClientSites))]
        public virtual Countries Country { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(SecUser.ClientSitesCreatedBy))]
        public virtual SecUser CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        [InverseProperty(nameof(SecUser.ClientSitesLastModifiedBy))]
        public virtual SecUser LastModifiedBy { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("ClientSites")]
        public virtual State State { get; set; }
        [InverseProperty("ClientSite")]
        public virtual ICollection<ClientProjects> ClientProjects { get; set; }
    }
}
