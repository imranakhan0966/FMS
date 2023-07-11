using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
    public class SecUserModel
    {
        public long Id { get; set; }
      
       
        public string UserName { get; set; }
       
        public string FullName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime? PwdChangeDateTime { get; set; }
        public DateTime? ProfileExpiryDate { get; set; }
        //public long? BaseLocationId { get; set; }
        //[MaxLength(50)]
        public string SecurityKey { get; set; }
        public long DepartmentId { get; set; }
       
        public bool? IsActive { get; set; }
        public DateTime? LockedDateTime { get; set; }
        public int AccessFailedCount { get; set; }
        public long RoleId { get; set; }
       
        public long? UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public DateTime? RetirementDate { get; set; }
        [MaxLength(50)]
        public string Designation { get; set; }
        public Boolean IsSubmitted { get; set; }
        public string Remarks { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
        public bool? IsAuthorized { get; set; }
        
         public bool? IsClosed { get; set; }
        public bool SbpAllowed { get; set; }
        public long? PrefixId { get; set; }
        public string PrefixNmae { get; set; }
        public long? CountryId { get; set; }
        public string CountryName { get; set; }
        public long? CityId { get; set; }
        public string CityName { get; set; }
        public long? StateId { get; set; }
        public string StateName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [StringLength(30)]
        public string Mobile { get; set; }
        [StringLength(30)]
        public string Telephone { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
      
        public DateTime? DateOfBirth { get; set; }
    
        [StringLength(50)]
        public string Ircanumber { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public string PhotoPath { get; set; }
        public string PhotoContentType { get; set; }
        public string ConfidentialityPath { get; set; }
        public string ConfidentialityContentType { get; set; }
        public string ContractPath { get; set; }
        public string ContractContentType { get; set; }
        //public List<SecUserLocationModel> SecUserLocation { get; set; }
        public string FirstName { get; set; }
        //public string ContractPath { get; set; }
        //public string ContractContentType { get; set; }

        public long? OrganizationId { get; set; }
        
        public string OrganizationName { get; set; }
        public string EmailForgotPassword { get; set; }
        public string RegistrationNo { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovelStatusId { get; set; }
        public string ApprovelStatus { get; set; }

        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long? AuthorizedBy { get; set; }
        public DateTime? AuthorizedDate { get; set; }
        public long? ParentUserId { get; set; }
        public string ParentUserName { get; set; }
        public long? ParentAgencyId { get; set; }
        public string ParentAgencyName { get; set; }
        public long? BuildingId { get; set; }
        public string BuildingName { get; set; }
        public long? FloorId { get; set; }
        public long? FlatId { get; set; }
        public List<UserStandardModel> UserStandardModel { get; set; }
        public List<UserDeclarationModel> UserDeclarationModel { get; set; }
        public List<UserAcademicModel> UserAcademicModel { get; set; }
        public List<UserEmploymentModel> UserEmploymentModel { get; set; }
        public List<UserCPDModel> UserCPDModel { get; set; }
        public List<UserProfessionalModel> UserProfessionalModel { get; set; }
        public List<UserConsultancyModel> UserConsultancyModel { get; set; }
        public List<UserAuditModel> UserAuditModel { get; set; }
        public List<UserAuditorNaceModel> UserAuditorNaceModel { get; set; }

    }
}
