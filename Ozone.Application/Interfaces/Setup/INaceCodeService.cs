using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface INaceCodeService
    {
        Task<string> Create(NaceCodeModel input);
        Task<GetPagedNaceCodeModel> GetPagedNaceCodeResponse(PagedResponseModel model);
        Task<NaceCodeModel> GetNaceCodeBYId(long id);
        Task<string> NaceCodeDeleteById(long id);

    }
}
