using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedUserProfessionalModel
    {
        public int TotalCount { get; set; }
        public List<UserProfessionalModel> UserProfessionalModel { get; set; }
    }
}
