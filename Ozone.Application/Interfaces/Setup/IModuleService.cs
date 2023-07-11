using Ozone.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface IModuleService
    {
        Task<string> Create(ModuleModel input);
        Task<GetPagedModuleModel> GetPagedModuleResponse(PagedResponseModel model);
        Task<ModuleModel> GetModuleBYId(long id);
        Task<string> ModuleDeleteById(long id);
    }
}
