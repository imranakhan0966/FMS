using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
    public class LoginResultModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public long UserId { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }
        public string LocationName { get; set; }
        public long LocationId { get; set; }
        public long? LocationTypeId { get; set; }
        public bool SbpAllowed { get; set; }
        public long? OrganizationId { get; set; }
        public long? UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string OrganizationName { get; set; }


    }
}
