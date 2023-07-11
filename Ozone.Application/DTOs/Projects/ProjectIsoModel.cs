using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class ProjectIsoModel
    {


        public long? ClientSiteId { get; set; }
        public long? VerificationTypeId { get; set; }
        public string LegalStatus { get; set; }
        public string OutsourceProductionProcessess { get; set; }
        public int? TotalEmployees { get; set; }
        public string ShiftTimings { get; set; }
        public string Address { get; set; }

        public long Id { get; set; }

        public string Code { get; set; }
        public long? ProjectTypeId { get; set; }
        public long? ClientProjectId { get; set; }
        public long? ServicesTypeId { get; set; }
        public string TotalOccupancy { get; set; }
        public string NoOperationalShifts { get; set; }
        public long? NumberEmployees { get; set; }
        public long? NumberPartTimeEmployees { get; set; }
        public long? StageCertification { get; set; }
        public string Accreditation { get; set; }
        public string ScopeCodeEvaluation { get; set; }

        public IFormFile ApplicationForm { get; set; }
        public string ApplicationFormPath { get; set; }
        public string ApplicationContentType { get; set; }
        public string Remarks { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedById { get; set; }
        public string BussinessScope { get; set; }
        public DateTime? ApplicationDate { get; set; }


        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovedById { get; set; }

        public DateTime? ApprovedDate { get; set; }
        public long? ApprovalStatusId { get; set; }
      
        public long? AccreditationId { get; set; }
        public long? StandardId { get; set; }
        public long? ClientId { get; set; }
    }
}
