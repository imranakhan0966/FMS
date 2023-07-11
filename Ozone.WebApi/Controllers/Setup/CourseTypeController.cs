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
    public class CourseTypeController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        ICourseTypeService _CourseTypeService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public CourseTypeController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            ICourseTypeService CourseTypeService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._CourseTypeService = CourseTypeService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CourseTypeModel input)
        {

            var result = await _CourseTypeService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedCourseType")]
        [HttpPost]
        public async Task<IActionResult> GetPagedCourseType(PagedResponseModel model)
        {
            var list = await _CourseTypeService.GetPagedCourseTypeResponse(model);
            return new JsonResult(list);
        }

        [Route("GetCourseTypeDataById")]
        [HttpGet]
        public async Task<IActionResult> GetCourseTypeDataById(int id)
        {
            var list = await _CourseTypeService.GetCourseTypeBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("CourseTypeDeleteById")]
        public async Task<IActionResult> CourseTypeDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _CourseTypeService.CourseTypeDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
