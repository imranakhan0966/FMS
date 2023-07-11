using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedUserAcademicModel
    {
        public int TotalCount { get; set; }
        public List<UserAcademicModel> UserAcademicModel { get; set; }
    }
}
