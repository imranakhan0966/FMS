using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedUserAuditModel
    {
        public int TotalCount { get; set; }
        public List<UserAuditModel> UserAuditModel { get; set; }
    }
}
