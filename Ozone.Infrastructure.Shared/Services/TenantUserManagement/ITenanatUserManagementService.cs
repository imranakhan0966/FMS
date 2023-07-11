using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure
{
   public interface ITenanatUserManagementService
    {
        Task<List<SecUserModel>> GetAllUsers(AdvanceQueryParameter queryParameter);
        Task<SecUserModel> GetUserById(long userId);
        Task<string> UpdateUserManagement(long id ,UserDataWithFilesModel input);
        Task<string> CreateUserManagement(UserDataWithFilesModel input);
    }
}
