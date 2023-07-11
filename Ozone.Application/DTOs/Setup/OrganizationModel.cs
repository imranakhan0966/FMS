using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{ 
  public  class OrganizationModel
    {
        public long Id { get; set; }
    
        public string Code { get; set; }
   
        public string Name { get; set; }
   
        public string Description { get; set; }
      
        public string ContactNumber { get; set; }
      
        public string Email { get; set; }
       
        public string ContactPerson { get; set; }
     
        public string PersonContactNumber { get; set; }
      
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

        //for user
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailForgotPassword { get; set; }
        public long? RoleId { get; set; }
        public long? StateId { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public DateTime? JoiningDate { get; set; }



    }
}
