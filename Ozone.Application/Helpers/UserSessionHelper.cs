using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application
{
    public class UserSessionHelper : IUserSessionHelper
    
    {
        private long _userId;
        private string _userName;
        private string _emailAddress;
        private long _roleId;
        private long _locationId;
        private long _locationTypeId;
        private DateTime _loginDateTime;
        public long UserId { get => _userId; set => _userId = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string EmailAddress { get => _emailAddress; set => _emailAddress = value; }
        public DateTime LoginDateTime { get => _loginDateTime; set => _loginDateTime = value; }
        public long RoleId { get => _roleId; set => _roleId = value; }
        public long LocationId { get => _locationId; set => _locationId = value; }
        public long LocationTypeId { get => _locationTypeId; set => _locationTypeId = value; }
    }
}
