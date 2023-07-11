using Ozone.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.WebApi
{
    public class LoginResult
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
        public DateTime expiration { get; set; }
        public List<SecRoleFormLoginModel> SecRoleForm { get; set; }
        public string roleName { get; set; }
        public long userId { get; set; }

        public string userName { get; set; }
        public long locationId { get; set; }
        public long? locationTypeId { get; set; }
        public string locationName { get; set; }
        public string message { get; set; }

        public bool userSbpAllowed { get; set; }
        public long? organizationId { get; set; }
         public long? userTypeId { get; set; }
        public long? roleId { get; set; }
        public string firstName { get; set; }
        public string organizationName { get; set; }






    }
}
