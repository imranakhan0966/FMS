using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class StandardController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IStandardService _StandardService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public StandardController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IStandardService standardService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._StandardService = standardService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CertificationModel input)
        {
          
            var result = await _StandardService.Create(input);
            return Ok(new Response { Status = result, Message = result });

         

        }
        [Route("GetPagedStandard")]
        [HttpPost]
        public async Task<IActionResult> GetPagedStandard(PagedResponseModel model)
        {
            var list = await _StandardService.GetPagedStandardResponse(model);
            return new JsonResult(list);
        }

        [Route("GetStandardDataById")]
        [HttpGet]
        public async Task<IActionResult> GetStandardDataById(int id)
        {
            var list = await _StandardService.GetStandardBYId(id);
            return new JsonResult(list);


        }
        [HttpPost]
        [Route("StandardDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> StandardDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _StandardService.StandardDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

    }
}
