using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedModuleModel
    {
        public int TotalCount { get; set; }
        public List<ModuleModel> ModuleModel { get; set; }
    }
}
