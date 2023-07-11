using Ozone.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ozone.WebApi
{
    public class CustomJwtBearerEvents : JwtBearerEvents
    {
        IUserSessionHelper _userSession;
        public CustomJwtBearerEvents(IUserSessionHelper userSession)
        {
            _userSession = userSession;
        }
        public override Task TokenValidated(TokenValidatedContext context)
        {
            // Add the access_token as a claim, as we may actually need it
            var accessToken = context.SecurityToken as JwtSecurityToken;
            Claim userIdClaim = accessToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId);
            _userSession.UserId = userIdClaim == null ? 0 : Convert.ToInt64(userIdClaim.Value);
            Claim userNameClaim = accessToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.UniqueName);
            _userSession.UserName = userNameClaim == null ? string.Empty : userNameClaim.Value;
            Claim emailClaim = accessToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email);
            _userSession.EmailAddress = emailClaim == null ? string.Empty : emailClaim.Value;
            Claim roleIdClaim = accessToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Typ);
            _userSession.RoleId = roleIdClaim == null ? 0 : Convert.ToInt64(roleIdClaim.Value);
            Claim loginDateTimeClaim = accessToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.AuthTime);
            _userSession.LoginDateTime = loginDateTimeClaim == null ? DateTime.MinValue : Convert.ToDateTime(loginDateTimeClaim.Value);
          //  Claim locIdClaim = accessToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid);
           // _userSession.LocationId = locIdClaim == null ? 0 : Convert.ToInt64(locIdClaim.Value);
           // Claim locTypeIdClaim = accessToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
           //// _userSession.LocationTypeId = locTypeIdClaim == null ? 0 : Convert.ToInt64(locTypeIdClaim.Value);
            //if (Guid.TryParse(accessToken.Id, out Guid sessionId))
            //{
            //    if (await _userSession.ValidateSessionAsync(sessionId))
            //    {
            //        return;
            //    }
            //}
            //throw new SecurityTokenValidationException("Session not valid for provided token.");
            return Task.FromResult<object>(null);//This will compile
            
        }

//        x.Events = new JwtBearerEvents
//                {
//                    OnTokenValidated = (context) =>
//                    {
//                        var user = context.Principal;
//                        //Check if already restored during current request
//                        if (user.GetDefaultUserPrincipal() == null)
//                        {
//                            var securityManager = context.HttpContext.RequestServices.GetRequiredService<ISecurityManager>();
//        var authResponse = await securityManager.AuthenticateMarketplaceFromBearerRequestAsync(user);

//                            if (!authResponse.IsAuthenticated)
//                            {
//                                context.Fail(authResponse.Message);
//                            }
//}
//                    }
//                };
    }
}
