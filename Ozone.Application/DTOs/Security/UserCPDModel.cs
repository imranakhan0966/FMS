using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class UserCPDModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Course { get; set; }
        public string Organization { get; set; }
        public string Details { get; set; }
        public long? StandardId { get; set; }
        public string StandardName { get; set; }
        public int? Year { get; set; }
        public long? TypeId { get; set; }
       
        public string Hours { get; set; }
        public IFormFile DocumentFile { get; set; }
        public string DocumentsContentType { get; set; }
        public string DocumentsFilePath { get; set; }
        public long? ApprovedBy { get; set; }
       
        public DateTime? ApprovedDate { get; set; }
        public long? CreatedBy { get; set; }
       
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
       
        public DateTime? LastModifiedDate { get; set; }
    }
}
