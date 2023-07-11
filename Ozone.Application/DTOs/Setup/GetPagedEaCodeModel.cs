using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedEaCodeModel
    {
        public int TotalCount { get; set; }
        public List<EACodeModel> EaCodeModel { get; set; }
    }
}
