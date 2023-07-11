using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedStandardTypeModel
    {
        public int TotalCount { get; set; }
        public List<StandardTypeModel> StandardTypeModel { get; set; }
    }
}
