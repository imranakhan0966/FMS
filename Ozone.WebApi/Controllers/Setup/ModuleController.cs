
using Microsoft.AspNetCore.Mvc;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Interfaces.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;


namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IModuleService _ModuleService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public ModuleController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IModuleService ModuleService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._ModuleService = ModuleService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ModuleModel input)
        {

            var result = await _ModuleService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }
        [Route("GetPagedModule")]
        [HttpPost]
        public async Task<IActionResult> GetPagedModule(PagedResponseModel model)
        {
            var list = await _ModuleService.GetPagedModuleResponse(model);
            return new JsonResult(list);
        }

        [Route("GetModuleDataById")]
        [HttpGet]
        public async Task<IActionResult> GetModuleDataById(int id)
        {
            var list = await _ModuleService.GetModuleBYId(id);
            return new JsonResult(list);


        }
        [HttpPost]
        [Route("ModuleDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> ModuleDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _ModuleService.ModuleDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

    }
}

