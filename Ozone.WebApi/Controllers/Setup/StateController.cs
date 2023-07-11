using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Interfaces.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ozone.Application.Parameters;

namespace Ozone.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IStateService _StateService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public StateController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IStateService StateService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._StateService = StateService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var list = await _StateService.GetAllStates(queryParameter);
            return new JsonResult(list);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(StateModel input)
        {

            var result = await _StateService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedState")]
        [HttpPost]
        public async Task<IActionResult> GetPagedState(PagedResponseModel model)
        {
            var list = await _StateService.GetPagedStateResponse(model);
            return new JsonResult(list);
        }

        [Route("GetStateDataById")]
        [HttpGet]
        public async Task<IActionResult> GetStateDataById(int id)
        {
            var list = await _StateService.GetStateBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("StateDeleteById")]
        public async Task<IActionResult> StateDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _StateService.StateDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
