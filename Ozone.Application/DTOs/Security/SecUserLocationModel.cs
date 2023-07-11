using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
   public class SecUserLocationModel
    {
        public long Id { get; set; }
        public long SecUserId { get; set; }
        public long LocationId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }


    }
}
