using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedNaceCodeModel
    {
        public int TotalCount { get; set; }
        public List<NaceCodeModel> NaceCodeModel { get; set; }
    }
}
