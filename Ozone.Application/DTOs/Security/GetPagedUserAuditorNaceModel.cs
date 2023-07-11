using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class GetPagedUserAuditorNaceModel
    {
        public int TotalCount { get; set; }
        public List<UserAuditorNaceModel> UserAuditorNaceModel { get; set; }
    }
}
