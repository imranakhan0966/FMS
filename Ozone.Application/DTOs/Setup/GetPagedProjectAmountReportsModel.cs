using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class GetPagedProjectAmountReportsModel
    {
        public int TotalCount { get; set; }
        public List<ClientProjectModel> ProjectAmountModel { get; set; }

    }
}
