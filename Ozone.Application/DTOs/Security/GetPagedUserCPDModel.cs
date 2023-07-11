using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedUserCPDModel
    {
        public int TotalCount { get; set; }
        public List<UserCPDModel> UserCPDModel { get; set; }
    }
}
