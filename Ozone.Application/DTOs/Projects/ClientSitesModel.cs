using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class ClientSitesModel
    {
        public long Id { get; set; }
       
        public string Code { get; set; }
        public long ClientId { get; set; }
        public string ClientName { get; set; }

        public string SiteName { get; set; }
       
        public string LegalStatus { get; set; }
        public string OutsourceProductionProcessess { get; set; }
        public int? TotalEmployees { get; set; }
        public string ShiftTimings { get; set; }
        public string Address { get; set; }
        public long? CountryId { get; set; }
        public string CountryName { get; set; }
        public long? StateId { get; set; }
        public string StateName { get; set; }
      
        public long? CityId { get; set; }
        public string CityName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedById { get; set; }
      
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedById { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
     
        public DateTime? LastModifiedDate { get; set; }

        public string AgencyCode { get; set; }
        public string ClientCode { get; set; }
      
        public string StandardCode { get; set; }

        public string StandardName { get; set; }

        public string AgencyName { get; set; }
        public long? OverAllEmployees { get; set; }


    }
}
