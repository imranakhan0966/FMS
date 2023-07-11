using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedLegislationModel
    {
        public int TotalCount { get; set; }
        public List<LegislationModel> LegislationModel { get; set; }
    }
}
