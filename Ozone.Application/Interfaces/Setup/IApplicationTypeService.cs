using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface IApplicationTypeService
    {
        Task<string> Create(ApplicationTypeModel input);
        Task<GetPagedApplicationTypeModel> GetPagedApplicationTypeResponse(PagedResponseModel model);
        Task<ApplicationTypeModel> GetApplicationTypeBYId(long id);
        Task<string> ApplicationTypeDeleteById(long id);
    }
}
