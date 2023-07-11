using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs.Projects
{
   public class WorkProgressHistoryModel
    {

        public long Id { get; set; }
        public long? UserId { get; set; }
        public string UserName { get; set; }
        public string Commemts { get; set; }
        public DateTime? CommemtsDate { get; set; }
        public long? ServiceId { get; set; }
    }
}
