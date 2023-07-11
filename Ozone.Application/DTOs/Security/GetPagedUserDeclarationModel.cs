using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedUserDeclarationModel
    {
        public int TotalCount { get; set; }
        public List<UserDeclarationModel> UserDeclarationsModel { get; set; }
    }
}
