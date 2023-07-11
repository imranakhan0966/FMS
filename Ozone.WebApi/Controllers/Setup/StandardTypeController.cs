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
    public class StandardTypeController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IStandardTypeService _StandardTypeService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public StandardTypeController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IStandardTypeService StandardTypeService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._StandardTypeService = StandardTypeService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(StandardTypeModel input)
        {

            var result = await _StandardTypeService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedStandardType")]
        [HttpPost]
        public async Task<IActionResult> GetPagedStandard(PagedResponseModel model)
        {
            var list = await _StandardTypeService.GetPagedStandardTypeResponse(model);
            return new JsonResult(list);
        }

        [Route("GetStandardTypeDataById")]
        [HttpGet]
        public async Task<IActionResult> GetStandardTypeDataById(int id)
        {
            var list = await _StandardTypeService.GetStandardTypeBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("StandardTypeDeleteById")]
        public async Task<IActionResult> StandardTypeDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _StandardTypeService.StandardTypeDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
