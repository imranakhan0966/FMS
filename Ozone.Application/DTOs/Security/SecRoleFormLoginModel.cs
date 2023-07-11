using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
    public class SecRoleFormLoginModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long FormId { get; set; }
        public string FormName { get; set; } // Indent Request
        public string FormCode { get; set; } // indent-request etc.
        public bool InsertAllowed { get; set; }
        public bool UpdateAllowed { get; set; }
        public bool QueryAllowed { get; set; }
        public bool AuthAllowed { get; set; }
        public bool SbpAllowed { get; set; }
        public bool? ManageAllowed { get; set; }
        public bool? DeleteAllowed { get; set; }
        public bool? ViewRecordAllowed { get; set; }

    }
}
