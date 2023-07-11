using Ozone.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface IStandardService
    {
        Task<string> Create(CertificationModel input);
       // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseModel model);
        Task<CertificationModel> GetStandardBYId(long id);
        //Task<List<CertificationModel>> GetAllModule();

        Task<string> StandardDeleteById(long id);
    }
}
