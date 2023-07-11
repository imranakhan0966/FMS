using Ozone.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.Interfaces.Setup
{
  
        public class GetPagedUserStandardModel
        {
            public int TotalCount { get; set; }
            public List<UserStandardModel> UserStandardModel { get; set; }
        }
    
}
