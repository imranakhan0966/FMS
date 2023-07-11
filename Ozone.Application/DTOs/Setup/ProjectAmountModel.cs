using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public  class ProjectAmountModel
    {
        public long Id { get; set; }   
        public string Code { get; set; }
        public long? OrganizationId { get; set; }
        public string Agency { get; set; }
        public DateTime? Date { get; set; }
        public long? StandardId { get; set; }
        public string StandardName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime? LastupdatedDate { get; set; }
        public long? LastupdatedId { get; set; }
    }
}
