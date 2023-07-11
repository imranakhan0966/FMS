using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface IEaCodeService
    {
        Task<string> Create(EACodeModel input);
        Task<GetPagedEaCodeModel> GetPagedEaCodeResponse(PagedResponseModel model);
        Task<EACodeModel> GetEaCodeBYId(long id);
        Task<string> EaCodeDeleteById(long id);

    }
}
