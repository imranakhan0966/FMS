using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedProjectRemarksModel
    {
        
            public int TotalCount { get; set; }
            public List<ProjectRemarksHistoryModel> ProjectRemarksHistoryModel { get; set; }

        
    }
}
