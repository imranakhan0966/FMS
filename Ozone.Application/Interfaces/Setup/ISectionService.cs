using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface ISectionService
    {
        Task<string> Create(SectionModel input);
        Task<GetPagedSectionModel> GetPagedSectionResponse(PagedResponseModel model);
        Task<SectionModel> GetSectionBYId(long id);
        Task<string> SectionDeleteById(long id);

    }
}
