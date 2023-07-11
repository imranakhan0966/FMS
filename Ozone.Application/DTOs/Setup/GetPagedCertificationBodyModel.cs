using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class GetPagedCertificationBodyModel
    {
        public int TotalCount { get; set; }
        public List<CertificationBodyModel> CertificationBodyModel { get; set; }
    }
}
