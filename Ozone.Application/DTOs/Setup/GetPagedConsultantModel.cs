using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedConsultantModel
    {
        public int TotalCount { get; set; }
        public List<ConsultantModel> ConsultantModel { get; set; }

    }
}
