using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class LibraryResourcesModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public DateTime? Date { get; set; }
         public long? Reviewer { get; set; }
    
        public long? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public long? StatusId { get; set; }
        public string Status { get; set; }
        public long? DocumentTypeId { get; set; }
        public long? CertificationId { get; set; }
        public string StandardName { get; set; }
        public long? AuthorizedBy { get; set; }

        public DateTime? AuthorizedDate { get; set; }
        public bool? IsSubmitted { get; set; }
        public bool? IsAuthorized { get; set; }

        public string Remarks { get; set; }
        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public IFormFile File { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
    }
}
