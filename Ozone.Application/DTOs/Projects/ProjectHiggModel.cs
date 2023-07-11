using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class ProjectHiggModel
    {



        public long ClientSiteId { get; set; }
        public long VerificationTypeId { get; set; }
        public string LegalStatus { get; set; }
        public string OutsourceProductionProcessess { get; set; }
        public int? TotalEmployees { get; set; }
        public string ShiftTimings { get; set; }
        public string Address { get; set; }



        //ProjectHig
        public long Id { get; set; }
      
        public string Code { get; set; }
        public long? ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public long? ClientProjectId { get; set; }
      
        public long? ServicesTypeId { get; set; }
        public string ServicesTypeName { get; set; }
        public long? MethodologyId { get; set; }
        public string MethodologyName { get; set; }

        public DateTime? FromDate { get; set; }
       
        public DateTime? ToDate { get; set; }
   
        public DateTime? ApplicationDate { get; set; }
        public long? AssessmentCompletedId { get; set; }
        public long? CompletedModuleId { get; set; }
        public string ManufacturingProcessess { get; set; }
        public long? EffluentTreatmentPlantId { get; set; }
        public long? NoOfMd { get; set; }
        public long? ModuleVersionId { get; set; }
       
        public DateTime? BodySelectDate { get; set; }
        public long? ModuleShareId { get; set; }
       
        public DateTime? WindowPeriodDate { get; set; }
        public long? ModuleYear { get; set; }
        public IFormFile ApplicationForm { get; set; }
        public string ApplicationFormPath { get; set; }
        public string ApplicationContentType { get; set; }
        public string Remarks { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
     
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }
       
        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovedById { get; set; }
   
        public DateTime? ApprovedDate { get; set; }
        public long? ApprovalStatusId { get; set; }
        public long? RequestOfSiteId { get; set; }
        public long StandardId { get; set; }

        public long? ClientId { get; set; }

    }
}
