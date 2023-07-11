using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.DTOs
{
   public class SecUserPagedModel
    {
        public int TotalCount { get; set; }
        public List<SecUserModel> SecUserModel { get; set; }
       
    }
}
