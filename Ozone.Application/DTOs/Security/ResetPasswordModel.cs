using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class ResetPasswordModel
    {
       
            public long Id { get; set; }

            //public string Email { get; set; }

           // public string Password { get; set; }
            public long? LastUpadatedById { get; set; }

       
   
       
        public string Description { get; set; }
      
        public string EmailAddress { get; set; }
       
        public string Title { get; set; }
     
        public string Subject { get; set; }
      
        public string Password { get; set; }
        public long? OrganizationId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
      
        public DateTime? CreatedByDate { get; set; }
        public long? LastModifiedById { get; set; }
        
        public DateTime? LastModifiedByDate { get; set; }
       
        public string Body { get; set; }
        public long? UserId { get; set; }
    }
    
}
