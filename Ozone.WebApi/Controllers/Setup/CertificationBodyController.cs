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
    public class CertificationBodyController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        ICertificationBodyService _CertificationBodyService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public CertificationBodyController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            ICertificationBodyService CertificationBodyService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._CertificationBodyService = CertificationBodyService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CertificationBodyModel input)
        {

            var result = await _CertificationBodyService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedCertificationBody")]
        [HttpPost]
        public async Task<IActionResult> GetPagedCertification(PagedResponseModel model)
        {
            var list = await _CertificationBodyService.GetPagedCertificationBodyResponse(model);
            return new JsonResult(list);
        }

        [Route("GetCertificationBodyDataById")]
        [HttpGet]
        public async Task<IActionResult> GetCertificationBodyDataById(int id)
        {
            var list = await _CertificationBodyService.GetCertificationBodyBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("CertificationBodyDeleteById")]
        public async Task<IActionResult> CertificationBodyDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _CertificationBodyService.CertificationBodyDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
