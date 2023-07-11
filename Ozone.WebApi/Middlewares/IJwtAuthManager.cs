using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Ozone.WebApi
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string username, List<Claim> claims, DateTime now);
        void RemoveRefreshTokenByUserName(string userName);
        JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);
    }
}