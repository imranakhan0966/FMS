using Ozone.Application.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class GetPagedProjectLedgerModel
    {
        public int TotalCount { get; set; }
        public List<ProjectLedgerModel> ProjectLedgerModel { get; set; }
    }
}
