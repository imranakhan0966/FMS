using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedUserRemarksModel
    {
        public int TotalCount { get; set; }
        public List<UserRemarksModel> UserRemarksModel { get; set; }

    }

}
