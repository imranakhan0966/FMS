using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Ozone.Application.DTOs;

using Ozone.Application.Interfaces.Service;
using Ozone.Application.Interfaces.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class EaCodeController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IEaCodeService _EaCodeService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public EaCodeController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IEaCodeService EaCodeService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._EaCodeService = EaCodeService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(EACodeModel input)
        {

            var result = await _EaCodeService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedEaCode")]
        [HttpPost]
        public async Task<IActionResult> GetPagedEaCode(PagedResponseModel model)
        {
            var list = await _EaCodeService.GetPagedEaCodeResponse(model);
            return new JsonResult(list);
        }

        [Route("GetEaCodeDataById")]
        [HttpGet]
        public async Task<IActionResult> GetEaCodeDataById(int id)
        {
            var list = await _EaCodeService.GetEaCodeBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("EaCodeDeleteById")]
        public async Task<IActionResult> EaCodeDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _EaCodeService.EaCodeDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
