using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedSectionModel
    {
        public int TotalCount { get; set; }
        public List<SectionModel> SectionModel { get; set; }
    }
}
