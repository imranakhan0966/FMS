using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs.Security
{
    public class SecRolePagedModel
    {
        public int TotalCount { get; set; }
        public List<SecRoleFormPagedModel> SecRoleFormPagedModel { get; set; }
    }
}
