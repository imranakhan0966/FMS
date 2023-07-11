using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Setup;
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
    public class ApplicationTypeController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IApplicationTypeService _ApplicationTypeService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public ApplicationTypeController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IApplicationTypeService ApplicationTypeService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._ApplicationTypeService = ApplicationTypeService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationTypeModel input)
        {

            var result = await _ApplicationTypeService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedApplicationType")]
        [HttpPost]
        public async Task<IActionResult> GetPagedApplicationType(PagedResponseModel model)
        {
            var list = await _ApplicationTypeService.GetPagedApplicationTypeResponse(model);
            return new JsonResult(list);
        }

        [Route("GetApplicationTypeDataById")]
        [HttpGet]
        public async Task<IActionResult> GetApplicationTypeDataById(int id)
        {
            var list = await _ApplicationTypeService.GetApplicationTypeBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("ApplicationTypeDeleteById")]
        public async Task<IActionResult> ApplicationTypeDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _ApplicationTypeService.ApplicationTypeDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
