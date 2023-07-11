using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface IAccreditationService
    {
        Task<string> Create(AccreditationModel input);
        Task<GetPagedAccreditationModel> GetPagedAccreditationResponse(PagedResponseModel model);
        Task<AccreditationModel> GetAccreditationBYId(long id);
        Task<string> AccreditationDeleteById(long id);

    }
}
