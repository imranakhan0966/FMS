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
    public class SectionController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        ISectionService _SectionService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public SectionController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            ISectionService SectionService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._SectionService = SectionService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(SectionModel input)
        {

            var result = await _SectionService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedSection")]
        [HttpPost]
        public async Task<IActionResult> GetPagedSection(PagedResponseModel model)
        {
            var list = await _SectionService.GetPagedSectionResponse(model);
            return new JsonResult(list);
        }

        [Route("GetSectionDataById")]
        [HttpGet]
        public async Task<IActionResult> GetSectionDataById(int id)
        {
            var list = await _SectionService.GetSectionBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("SectionDeleteById")]
        public async Task<IActionResult> SectionDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _SectionService.SectionDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
