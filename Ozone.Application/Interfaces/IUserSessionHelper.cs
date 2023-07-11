using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application
{
    public interface IUserSessionHelper
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LoginDateTime { get; set; }
        public long RoleId { get; set; }
        public long LocationId { get; set; }
        public long LocationTypeId { get; set; }
    }
}
