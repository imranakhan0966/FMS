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
    public class AudditorTypeController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IAudditorTypeService _AudditorTypeService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public AudditorTypeController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IAudditorTypeService AudditorTypeService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._AudditorTypeService = AudditorTypeService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(AudditorTypeModel input)
        {

            var result = await _AudditorTypeService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedAudditorType")]
        [HttpPost]
        public async Task<IActionResult> GetPagedAudditorType(PagedResponseModel model)
        {
            var list = await _AudditorTypeService.GetPagedAudditorTypeResponse(model);
            return new JsonResult(list);
        }

        [Route("GetAudditorTypeDataById")]
        [HttpGet]
        public async Task<IActionResult> GetAudditorTypeDataById(int id)
        {
            var list = await _AudditorTypeService.GetAudditorTypeBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("AudditorTypeDeleteById")]
        public async Task<IActionResult> AudditorTypeDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _AudditorTypeService.AudditorTypeDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
