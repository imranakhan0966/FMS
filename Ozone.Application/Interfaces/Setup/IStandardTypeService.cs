using Ozone.Application.DTOs;


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface IStandardTypeService
    {
        Task<string> Create(StandardTypeModel input);
        Task<GetPagedStandardTypeModel> GetPagedStandardTypeResponse(PagedResponseModel model);
        Task<StandardTypeModel> GetStandardTypeBYId(long id);
        Task<string> StandardTypeDeleteById(long id);

    }
}
