using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.Parameters
{
    public class AdvanceQueryParameter
    {
        public string filters { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string sort { get; set; }
    }
}
