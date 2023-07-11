using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Ozone.Application.Interfaces
{
    public interface IUserAcademicService
    {
        Task<string> Create(UserAcademicModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserAcademicModel> GetPagedUserAcademicResponse(PagedResponseModel model);
        Task<UserAcademicModel> GetUserAcademicBYId(long id);
        Task<string> UserAcademicDeleteById(long id);
        Task<UserAcademicModel> DownloadFile(long id);


    }
}
