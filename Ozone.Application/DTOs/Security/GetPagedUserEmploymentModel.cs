using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs { 
  public  class GetPagedUserEmploymentModel
{
        public int TotalCount { get; set; }
        public List<UserEmploymentModel> UserEmploymentModel { get; set; }
}
}
