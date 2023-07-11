using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
  public  interface IAudditorTypeService
    {
        Task<string> Create(AudditorTypeModel input);
        Task<GetPagedAudditorTypeModel> GetPagedAudditorTypeResponse(PagedResponseModel model);
        Task<AudditorTypeModel> GetAudditorTypeBYId(long id);
        Task<string> AudditorTypeDeleteById(long id);
    }
}
