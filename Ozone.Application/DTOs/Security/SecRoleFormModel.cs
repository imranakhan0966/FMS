using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
   public class SecRoleFormModel
    {
        //public string Code { get; set; }
        //public long RoleId { get; set; }
        //public string RoleName { get; set; }
        public long Id { get; set; }
        public long PermissionId { get; set; }
        public string PermissionName { get; set; }
        public bool InsertAllowed { get; set; }
        public bool UpdateAllowed { get; set; }
        public bool QueryAllowed { get; set; }
        public bool AuthAllowed { get; set; }
    }

    public class SecRoleModelUpdate
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsSubmitted { get; set; }
        public string Remarks { get; set; }
        public List<SecRoleFormModel> SecRoleForm { get; set; }
        
    }
}
