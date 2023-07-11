using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class ProjectAmount
    {
        public ProjectAmount()
        {
            ClientProjects = new HashSet<ClientProjects>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [Column("Organization_id")]
        public long? OrganizationId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("Standard_id")]
        public long? StandardId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastupdatedDate { get; set; }
        public long? LastupdatedId { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal? Amount { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(SecUser.ProjectAmountCreatedByNavigation))]
        public virtual SecUser CreatedByNavigation { get; set; }
        [ForeignKey(nameof(LastupdatedId))]
        [InverseProperty(nameof(SecUser.ProjectAmountLastupdated))]
        public virtual SecUser Lastupdated { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("ProjectAmount")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(StandardId))]
        [InverseProperty(nameof(Certification.ProjectAmount))]
        public virtual Certification Standard { get; set; }
        [InverseProperty("ProjectAmount")]
        public virtual ICollection<ClientProjects> ClientProjects { get; set; }
    }
}
