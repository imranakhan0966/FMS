using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Authenticaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application
{
    public interface ICOIAuthenticationService
    {
        //public Task<List<GetUserDto>> GetAllAsync();
        Task<LoginResultModel> AuthenticateUser(LoginModel model);

        Task<ResetPasswordModel> ResetPasswordCount(long userId);
        Task<string> CheckPermission(long id);
    }
}
