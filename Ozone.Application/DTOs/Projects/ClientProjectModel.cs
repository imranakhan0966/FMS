using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class ClientProjectModel
    {
        public long Id { get; set; }
        public long? AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string ClientName { get; set; }
        public string ProjectCode { get; set; }
        public long ClientSiteId { get; set; }
        public long ClientId { get; set; }
        public string SiteName { get; set; }
        public long StandardId { get; set; }
        public string StandardName { get; set; }

        public DateTime? Date { get; set; }
        public long VerificationTypeId { get; set; }
        public string VerificationTypeName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovedById { get; set; }

        public DateTime? ApprovedDate { get; set; }
        public long? CreatedById { get; set; }
        public string CreatedByName { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public long? ApprovalStatusId { get; set; }
        public string ApprovalStatusName { get; set; }
        public long? ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public string Remarks { get; set; }

        public string AgencyCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientSiteCode { get; set; }
        public string StandardCode { get; set; }
        public IFormFile ContractForm { get; set; }
        public string ContractFilePath { get; set; }
        public string ContractFileContent { get; set; }

        public long? ProjectAmountId { get; set; }
        public decimal ProjectStandardAmount { get; set; }

    }
}
