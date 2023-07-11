using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Setup
{
    public class GetPagedProjectAmountModel
    {
        public int TotalCount { get; set; }
        public List<ProjectAmountModel> ProjectAmountModel { get; set; }
    }
}
