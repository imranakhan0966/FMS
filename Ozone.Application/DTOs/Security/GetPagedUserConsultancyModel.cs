using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class GetPagedUserConsultancyModel
    {
        public int TotalCount { get; set; }
        public List<UserConsultancyModel> UserConsultancyModel { get; set; }
    }
}
