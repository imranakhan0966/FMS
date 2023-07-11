using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ozone.Application.Interfaces.Service;
using Ozone.Infrastructure;

namespace Ozone.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayCalendarController : BaseApiController
    {
        private readonly IConfiguration _configuration;

        IAllDropdownService _AllDropdownService;
        ISecUserSessionService _userSessionService;
        IHolidayCalendarService _HolidayCalendarService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public HolidayCalendarController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IHolidayCalendarService HolidayCalendarService,
            IJwtAuthManager jwtAuthManager,
            IAllDropdownService allDropdownService
            )
        {
          
            _configuration = configuration;
            this._AllDropdownService = allDropdownService;
            this._userSessionService = userSessionService;
            this._HolidayCalendarService = HolidayCalendarService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(HolidayCalendarModel input)
        {

            var result = await _HolidayCalendarService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedHolidayCalendar")]
        [HttpPost]
        public async Task<IActionResult> GetPagedHolidayCalendar(PagedResponseModel model)
        {
            var list = await _HolidayCalendarService.GetPagedHolidayCalendarResponse(model);
            return new JsonResult(list);
        }

        [Route("GetHolidayCalendarDataById")]
        [HttpGet]
        public async Task<IActionResult> GetHolidayCalendarDataById(int id)
        {
            var list = await _HolidayCalendarService.GetHolidayCalendarBYId(id);
            return new JsonResult(list);


        }

        [Route("GetAllHolidayTypeList")]
        [HttpGet]
        public async Task<IActionResult> GetAllHolidayTypeList()
        {
            var List = await _AllDropdownService.GetAllHolidayTypeList();
            return new JsonResult(List);
        }

        [HttpPost]
        [Route("HolidayCalendarDeleteById")]
        public async Task<IActionResult> HolidayCalendarDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _HolidayCalendarService.HolidayCalendarDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
