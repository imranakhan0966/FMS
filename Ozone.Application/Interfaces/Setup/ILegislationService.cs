using Ozone.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface ILegislationService
    {
        Task<string> Create(LegislationModel input);
        Task<GetPagedLegislationModel> GetPagedLegislationResponse(PagedResponseModel model);
        Task<LegislationModel> GetLegislationBYId(long id);
        Task<string> LegislationDeleteById(long id);

    }
}
