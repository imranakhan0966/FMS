using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Ozone.Application.Interfaces

{
  public  interface IUserProfessionalService
    {
        Task<string> Create(UserProfessionalModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserProfessionalModel> GetPagedUserProfessionalResponse(PagedResponseModel model);
        Task<UserProfessionalModel> GetUserProfessionalBYId(long id);


        Task<string> UserProfessionalDeleteById(long id);
        Task<UserProfessionalModel> DownloadFile(long id);

    }
}
