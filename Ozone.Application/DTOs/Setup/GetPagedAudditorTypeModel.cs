using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Setup
{
   public class GetPagedAudditorTypeModel
    {
        public int TotalCount { get; set; }
        public List<AudditorTypeModel> AudditorTypeModel { get; set; }
    }
}
