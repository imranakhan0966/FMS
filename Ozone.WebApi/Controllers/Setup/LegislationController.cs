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
    public class LegislationController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        ILegislationService _LegislationService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public LegislationController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            ILegislationService LegislationService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._LegislationService = LegislationService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(LegislationModel input)
        {

            var result = await _LegislationService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedLegislation")]
        [HttpPost]
        public async Task<IActionResult> GetPagedLegislation(PagedResponseModel model)
        {
            var list = await _LegislationService.GetPagedLegislationResponse(model);
            return new JsonResult(list);
        }

        [Route("GetLegislationDataById")]
        [HttpGet]
        public async Task<IActionResult> GetLegislationDataById(int id)
        {
            var list = await _LegislationService.GetLegislationBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("LegislationDeleteById")]
        public async Task<IActionResult> LegislationDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _LegislationService.LegislationDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
