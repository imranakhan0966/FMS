using Ozone.Application.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class GetPagedProjectLedgerDetailModel
    {
        public int TotalCount { get; set; }
        public List<ProjectLedgerDetailModel> ProjectLedgerDetailModel { get; set; }
        public decimal? TotalReceivedAmount { get; set; }
        public decimal? BalanceAmount { get; set; }
        public decimal? InvoiceAmount { get; set; }
    }
}
