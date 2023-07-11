using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
    public class PagedResponseModel
    {
        public bool PidRequestApproval { get; set; }
        public bool isPidForm { get; set; }
        public bool AuthAllowed { get; set; }
        public string Keyword { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int locationId { get; set; }
        public int locationTypeId { get; set; }
        public long InventoryInOut { get; set; }
        public bool ViewAllRecord { get; set; }
        public long organizationId { get; set; }
        public long standardId { get; set; }
        public long projectId { get; set; }
        public long userId { get; set; }
        public long roleId { get; set; }


    }
}
