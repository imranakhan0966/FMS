using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedDocumentsTypeModel
    {
        public int TotalCount { get; set; }
        public List<DocumentsTypeModel> DocumentsTypeModel { get; set; }
    }
}
