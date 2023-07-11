using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class ConsultantModel
    {
       
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TellNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public long? CountryId { get; set; }
        public long? CityId { get; set; }
        public long? StateId { get; set; }
        public long? OrganizationId { get; set; }
        public long? PrefixId { get; set; }
       

        public long? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public long? LastUpdatedId { get; set; }


        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
