using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedStateModel
    {
        public int TotalCount { get; set; }
        public List<StateModel> StateModel { get; set; }
    }
}
