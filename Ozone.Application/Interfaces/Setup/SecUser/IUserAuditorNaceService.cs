using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Ozone.Application.Interfaces
{
  public  interface IUserAuditorNaceService
    {
        Task<string> Create(UserAuditorNaceModel input);
        Task<string> AuditorNaceSubmitForReviewStatus(long id);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserAuditorNaceModel> GetPagedUserAuditorNaceResponse(PagedResponseModel model);
        Task<UserAuditorNaceModel> GetUserAuditorNaceBYId(long id);


        Task<string> UserAuditorNaceDeleteById(long id);

        Task<string> AuditorNaceApproval(UserAuditorNaceModel input);

    }
}
