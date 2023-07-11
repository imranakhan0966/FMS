using Ozone.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface IConsultantService
    {
        Task<string> Create(ConsultantModel input);
        Task<GetPagedConsultantModel> GetPagedConsultantResponse(PagedResponseModel model);
        Task<ConsultantModel> GetConsultantBYId(long id);
        Task<string> ConsultantDeleteById(long id);
    }
}
