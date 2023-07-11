using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces
{
  public  interface IUserEmploymentService
    {
        Task<string> Create(UserEmploymentModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserEmploymentModel> GetPagedUserEmploymentResponse(PagedResponseModel model);
        Task<UserEmploymentModel> GetUserEmploymentBYId(long id);


        Task<string> UserEmploymentDeleteById(long id);
    }
}
