using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
    public class SecUserSessionModel
    {
        public long SecUserId { get; set; }
        public string UserName { get; set; }

       // public long? LocationId { get; set; }
        //public string LocationName { get; set; }

        public DateTime LoginDateTime { get; set; }
        public DateTime? LogoutDateTime { get; set; }
        public int? LoginCount { get; set; }
        [MaxLength(25)]
        public string MachineId { get; set; }
        [MaxLength(15)]
        public string IPAddress { get; set; }
    }
}
