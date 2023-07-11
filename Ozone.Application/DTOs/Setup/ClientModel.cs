using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class ClientModel
    {
        public long Id { get; set; }
       
        public string Code { get; set; }
      
        public string Name { get; set; }
       
        public string Description { get; set; }
     
        public string PhoneNumber { get; set; }
      
        public string MobileNumber { get; set; }
       
        public string Website { get; set; }
      
        public string Email { get; set; }
        public long? OrganizationId { get; set; }
       
        public string ContactPerson { get; set; }
       
        public string PersonContactNumber { get; set; }
     
        public string Address1 { get; set; }
       
        public string Address2 { get; set; }
        public long? CountryId { get; set; }
        public string CountryName { get; set; }
        public long? StateId { get; set; }
        public string StateName { get; set; }
        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public long? CityId { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public long? PrefixId { get; set; }
     
        public string Position { get; set; }
        public bool? IsActive { get; set; }
        public bool? Multisite { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public long? IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsProjectExist { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteCountry { get; set; }
        public int? SiteCount { get; set; }
        public long? OverAllEmployees { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationCode { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        //public string SiteContractName { get; set; }
        //public string SiteContractNumber { get; set; }
        //public string SiteEmail { get; set; }
        //public string RequestedService { get; set; }


    }
}
