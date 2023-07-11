using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs.Setup
{
  public  class GetPagedQcDocumentModel
    {
        public int TotalCount { get; set; }
        public List<QCDocumentsListModel> QCDocumentsListModel { get; set; }
    }
}
