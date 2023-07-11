using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class ServiceTypeModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
    public class ServiceStatusModel
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
    public class ServiceRequestModel
    {
     
        public long Id { get; set; }
    
        public string Code { get; set; }
  
        public string Title { get; set; }
   
        public string Description { get; set; }
        public long? ServiceTypeId { get; set; }
        public long? ClientId { get; set; }
        public long? BuildingId { get; set; }
        public long? FlatId { get; set; }
       
        public string Asset { get; set; }
        public long? PriorityId { get; set; }
        public string MaintainerComments { get; set; }
        public long? StatusId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
      
        public DateTime? LastModifiedDate { get; set; }
        public long? CompletedById { get; set; }
       
        public DateTime? CompletedDate { get; set; }

    }
    public class MethodologyModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
    public class AssessmentCompletedModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
    public class CompletedModuleModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
    public class EffluentTreatmentPlantModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
    public class ModuleVersionModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public long? StandardId { get; set; }
    }

    public class ModuleShareModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
    public class RequestOfSiteModel
    {
        public long Id { get; set; }
      
        public string Code { get; set; }
       
        public string Name { get; set; }
       
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
      
        public DateTime? LastModifiedDate { get; set; }
    }
}