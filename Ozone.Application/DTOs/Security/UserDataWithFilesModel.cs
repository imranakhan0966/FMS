using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class UserDataWithFilesModel
    {
        public long Id { get; set; }

       
        public string UserName { get; set; }
       public string LastName { get; set; }
        public string FullName { get; set; }
        
        public bool createdByUser { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public long? DepartmentId { get; set; }

        public bool? IsActive { get; set; }
      
        public long? RoleId { get; set; }
        public long? UserTypeId { get; set; }
       
    
      //  public string Designation { get; set; }
    
      
        public long? PrefixId { get; set; }
        public long? CountryId { get; set; }
        public long? ClientId { get; set; }
        public long? CityId { get; set; }
        public long? StateId { get; set; }

        public long? BuildingId { get; set; }
        public long? FloorId { get; set; }
        public long? FlatId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
   
        public string Mobile { get; set; }
      
        public string Telephone { get; set; }
      
        public string PostalCode { get; set; }

        public string DateOfBirth { get; set; }


        public string RegistrationNo { get; set; }

        public string Code { get; set; }
        public IFormFile PhotoFile { get; set; }
        //public string PhotoPath { get; set; }
        //public string PhotoContentType { get; set; }
        public IFormFile ConfidentialityFile { get; set; }
        //public string ConfidentialityPath { get; set; }
        //public string ConfidentialityContentType { get; set; }
        public IFormFile ContractFile { get; set; }

        public string FirstName { get; set; }
        //public string ContractPath { get; set; }
        //public string ContractContentType { get; set; }

        public long? OrganizationId { get; set; }
        public string EmailForgotPassword { get; set; }
        public long? CreatedBy { get; set; }
        public long? ParentUserId { get; set; }
    }
}
