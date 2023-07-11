using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class GetPagedLibraryModel
    {
        public int TotalCount { get; set; }
        public List<LibraryResourcesModel> LibraryModel { get; set; }
    }
}
