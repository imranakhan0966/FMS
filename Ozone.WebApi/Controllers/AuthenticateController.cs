using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Ozone.Infrastructure.Shared.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ozone.Infrastructure.Persistence;
using Ozone.Application.DTOs;
//using Ozone.Application.Interfaces.Service;
using Ozone.Infrastructure.Shared;
using Ozone.Infrastructure;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Ozone.Infrastructure.Persistence.Models;
using System.Security.Cryptography;
using System.Collections.Concurrent;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Interfaces;
using Ozone.Application;

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseApiController
    {
        
       
        private readonly IConfiguration _configuration;

       ICOIAuthenticationService _authService;
        ISecUserSessionService _userSessionService;
        ISecRoleService _secRoleService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public AuthenticateController(
           // UserService userService,
            IConfiguration configuration,
            ICOIAuthenticationService authService,
            ISecUserSessionService userSessionService,
            ISecRoleService secRoleService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
           // this._userService = userService;
            _configuration = configuration;
           this._authService = authService;
            this._userSessionService = userSessionService;
            this._secRoleService = secRoleService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [HttpPost]
        [Route("login")]
      
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            Log.Information("Login API called for user name: " + model.Username);
           
            LoginResultModel result = await _authService.AuthenticateUser(model);
          
            if (result != null) 
             {
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, result.Username),
                    new Claim(JwtRegisteredClaimNames.NameId, result.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, string.IsNullOrEmpty(result.Email) ? string.Empty : result.Email),
                    new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Typ, result.RoleId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sid, result.LocationId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, result.LocationTypeId.ToString())
                };

              
                var jwtResult = _jwtAuthManager.GenerateTokens(result.Username, authClaims, DateTime.Now);
        
             
            //      var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(authClaims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
                
            //    Byte[] secret = Encoding.ASCII.GetBytes(_jwtTokenConfig.Key);


            //    var jwtToken = new JwtSecurityToken(
            //        _jwtTokenConfig.Issuer,
            //        shouldAddAudienceClaim ? _jwtTokenConfig.Audience : string.Empty,
            //        authClaims,
            //        expires: DateTime.Now.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
              
            //signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));
            //    var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            //    var refreshToken = new RefreshToken
            //    {
            //        UserName = result.Username,
            //        TokenString = GenerateRefreshTokenString(),
            //        ExpireAt = DateTime.Now.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration)
            //    };
            //    _usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
            //    _usersRefreshTokens.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);
            //    JwtAuthResult Twt = new JwtAuthResult();
            //    Twt.AccessToken = accessToken;
            //    Twt.RefreshToken = refreshToken;
            //    Twt.ValidTo = jwtToken.ValidTo;
            //    var jwtResult = Twt;


                //{
                //    AccessToken = accessToken,
                //    RefreshToken = refreshToken,
                //    ValidTo = jwtToken.ValidTo
                //};
                //// HttpContext SignIn               
                //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(authClaims, CookieAuthenticationDefaults.AuthenticationScheme));
                //await HttpContext.SignInAsync(claimsPrincipal); //SysBase.cookieName, "user", "role"
                ////await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, User);

                // UserSession management
                string machineIPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

                SecUserSessionModel userSessionModel = new SecUserSessionModel();
                userSessionModel.SecUserId = result.UserId;
                userSessionModel.UserName = result.Username;
                userSessionModel.LoginDateTime = DateTime.Now;
                userSessionModel.IPAddress = machineIPAddress;
              
              userSessionModel = await _userSessionService.CreateUserSession(userSessionModel);

                // User Role Form Data
                //SecRoleService secRoleservice = new SecRoleService();
                var roleFormList = await _secRoleService.GetAllRoleFormByRoleId(result.RoleId);

               var resetPassword= await _authService.ResetPasswordCount(result.UserId);

                if (resetPassword!= null)
                {
                    if (resetPassword.UserId != resetPassword.CreatedById)
                    {
                        roleFormList = null;
                    }
                    

                }
                else
                {
                    roleFormList = null;
                }

                return Ok(new LoginResult()
                {
                    //token = new JwtSecurityTokenHandler().WriteToken(token),
                    //expiration = token.ValidTo,
                    token = jwtResult.AccessToken,
                    refreshToken = jwtResult.RefreshToken.TokenString,
                    expiration = jwtResult.ValidTo,


                    SecRoleForm = roleFormList,
                    userId = result.UserId,
                    userName = result.FirstName,
                    userSbpAllowed = result.SbpAllowed,
                    organizationId= result.OrganizationId,
                    userTypeId=result.UserTypeId,
                    roleId=result.RoleId,
                    organizationName=result.OrganizationName,
                    
                    //firstName = result.FirstName,
                //locationId = result.LocationId,
                //locationTypeId = result.LocationTypeId,
                //locationName = result.LocationName,
                message = result.Message

                });
            }
            Unauthorized(result);
            return Ok(new Response { Message = result.Message });

        }
        private static string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        //[HttpPost]
        //[Route("register")]
        //public IActionResult Register([FromBody] RegisterModel model)
        //{
        //    //var userExists = await userManager.FindByNameAsync(model.Username);
        //    //if (userExists != null)
        //    //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

        //    //SecUser user = new SecUser()
        //    //{
        //    //    Email = model.Email,
        //    //    SecurityStamp = Guid.NewGuid().ToString(),
        //    //    UserName = model.Username
        //    //};
        //    //var result = await userManager.CreateAsync(user, model.Password);
        //    //if (!result.Succeeded)
        //    //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        //    //return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        //    //var userExists = _secUserRepository.g(model.Username);
        //    var userExists = _userService.GetUser(model.Username);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

        //    SecUser user = new SecUser()
        //    {
        //        Email = model.Email,
        //        SecurityKey = Guid.NewGuid().ToString(),
        //        UserName = model.Username
        //    };
        //    var result = _userService.CreateUser(model.Username, model.Password, model.Email, string.Empty);
        //    if (!result)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        //    return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        //}

        //[HttpPost]
        //[Route("deleteUserSession")]
        //public async Task<IActionResult> DeleteUserSession(long userId)
        //{
        //    var message = await _userSessionService.DeleteUserSession(userId);
        //    return Ok(new Response { Message = message });

        //}

        //[HttpPost("logout")]
        //[Authorize]
        //public ActionResult Logout()
        //{
        //    var userName = User.Identity.Name;
        //    _jwtAuthManager.RemoveRefreshTokenByUserName(userName); // can be more specific to ip, user agent, device name, etc.
        //    Log.Information($"User [{userName}] logged out the system.");
        //    return Ok();
        //}

        //[HttpPost("refreshToken")]
        //[Authorize]
        //public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        //{
        //    try
        //    {
        //        var userName = User.Identity.Name;
        //        Log.Information($"User [{userName}] is trying to refresh JWT token.");

        //        if (string.IsNullOrWhiteSpace(request.RefreshToken))
        //        {
        //            return Unauthorized();
        //        }

        //        var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
        //        var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
        //        Log.Information($"User [{userName}] has refreshed JWT token.");
        //        return Ok(new LoginResult
        //        {
        //            userName = userName,
        //            roleName = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
        //            token = jwtResult.AccessToken,
        //            refreshToken = jwtResult.RefreshToken.TokenString
        //        });
        //    }
        //    catch (SecurityTokenException e)
        //    {
        //        return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
        //    }
        //}
        [Route("CheckPermission")]
        [HttpPost]
        public async Task<IActionResult> CheckPermission( long id)
        {

            var result = await _authService.CheckPermission(id);
            return Ok(new Response { Status = result, Message = result });



        }
    }
}
