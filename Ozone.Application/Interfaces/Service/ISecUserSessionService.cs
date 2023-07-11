using Ozone.Application.DTOs;
//using Ozone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Service
{
    public interface ISecUserSessionService
    {
        Task<SecUserSessionModel> CreateUserSession(SecUserSessionModel userSessionModel);
        Task<string> DeleteUserSession(long userId);
    }
}
