using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Projects
{
    public class ProjectLedgerModel
    {
        public long Id { get; set; }
        public long? ProjectId { get; set; }

        public decimal? Amount { get; set; }

        public decimal? ReceivedAmount { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedByDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public long StandardId { get; set; }
        public long? OrganizationId { get; set; }
        public string AgencyName { get; set; }
        public string ClientName { get; set; }
        public string StandardName { get; set; }
        public string ProjectCode { get; set; }
        //public decimal?  ReceivedAmount { get; set; }



    }
}
