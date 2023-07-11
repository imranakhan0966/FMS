using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class LibraryModelForCreate
    {
       

        

        public string Title { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        
        // public long? Reviewer { get; set; }
        public string Reviewer { get; set; }

        //public long? ModuleId { get; set; }
         public string ModuleId { get; set; }
       
        // public long? StatusId { get; set; }
        public string StatusId { get; set; }
        
        // public long? DocumentTypeId { get; set; }
        public string DocumentTypeId { get; set; }
        //   public long? CertificationId { get; set; }
        public string CertificationId { get; set; }
       // public long? AuthorizedBy { get; set; }

        
        
    

        //public string Remarks { get; set; }
        //public long? CreatedBy { get; set; }

      //  public DateTime? CreatedDate { get; set; }
        //public long? UpdatedBy { get; set; }

        //public DateTime? UpdatedDate { get; set; }
      

        public IFormFile File { get; set; }
       // public string FilePath { get; set; }
       // public string ContentType { get; set; }
    }
}
