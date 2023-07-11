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
    public class AccreditationController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IAccreditationService _AccreditationService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public AccreditationController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IAccreditationService AccreditationService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._AccreditationService = AccreditationService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(AccreditationModel input)
        {

            var result = await _AccreditationService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedAccreditation")]
        [HttpPost]
        public async Task<IActionResult> GetPagedAccreditation(PagedResponseModel model)
        {
            var list = await _AccreditationService.GetPagedAccreditationResponse(model);
            return new JsonResult(list);
        }

        [Route("GetAccreditationDataById")]
        [HttpGet]
        public async Task<IActionResult> GetAccreditationDataById(int id)
        {
            var list = await _AccreditationService.GetAccreditationBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("AccreditationDeleteById")]
        public async Task<IActionResult> AccreditationDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _AccreditationService.AccreditationDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
