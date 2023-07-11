using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class ProjectFormPathModel
    {
        public long Id { get; set; }
       
        public string Code { get; set; }
        public string Name { get; set; }
        public long? StandardId { get; set; }
        public string Path { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeletes { get; set; }
    }
}
