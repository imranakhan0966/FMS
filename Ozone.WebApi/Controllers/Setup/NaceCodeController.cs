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
    public class NaceCodeController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        INaceCodeService _NaceCodeService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public NaceCodeController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            INaceCodeService NaceCodeService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._NaceCodeService = NaceCodeService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(NaceCodeModel input)
        {

            var result = await _NaceCodeService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedNaceCode")]
        [HttpPost]
        public async Task<IActionResult> GetPagedNaceCode(PagedResponseModel model)
        {
            var list = await _NaceCodeService.GetPagedNaceCodeResponse(model);
            return new JsonResult(list);
        }

        [Route("GetNaceCodeDataById")]
        [HttpGet]
        public async Task<IActionResult> GetNaceCodeDataById(int id)
        {
            var list = await _NaceCodeService.GetNaceCodeBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("NaceCodeDeleteById")]
        public async Task<IActionResult> NaceCodeDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _NaceCodeService.NaceCodeDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
