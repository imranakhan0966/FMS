using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
    public class AuthorizeRejectModel
    {
        public long Id { get; set; }
        public bool IsPidInventoryIssued { get; set; }
        public string Remarks { get; set; }
    }
}
