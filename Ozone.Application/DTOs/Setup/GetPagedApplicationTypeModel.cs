using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Setup
{
   public class GetPagedApplicationTypeModel
    {
        public int TotalCount { get; set; }
        public List<ApplicationTypeModel> ApplicationTypeModel { get; set; }
    }
}
