using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedAccreditationModel
    {
        public int TotalCount { get; set; }
        public List<AccreditationModel> AccreditationModel { get; set; }
    }
}
