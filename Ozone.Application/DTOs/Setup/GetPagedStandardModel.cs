using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedStandardModel
    {
        public int TotalCount { get; set; }
        public List<CertificationModel> StandardModel { get; set; }
    }
}

