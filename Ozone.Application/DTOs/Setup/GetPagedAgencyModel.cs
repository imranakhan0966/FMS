using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedAgencyModel
    {
        public int TotalCount { get; set; }
        public List<OrganizationModel> OrganizationModel { get; set; }
    }
}
