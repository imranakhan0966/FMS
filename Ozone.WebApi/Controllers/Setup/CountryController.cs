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
    public class CountryController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        ICountryService _CountryService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public CountryController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            ICountryService CountryService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._CountryService = CountryService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetAllCounties([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var list = await _CountryService.GetAllCounties(queryParameter);
            return new JsonResult(list);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CountryModel input)
        {

            var result = await _CountryService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedCountry")]
        [HttpPost]
        public async Task<IActionResult> GetPagedCountry(PagedResponseModel model)
        {
            var list = await _CountryService.GetPagedCountryResponse(model);
            return new JsonResult(list);
        }

        [Route("GetCountryDataById")]
        [HttpGet]
        public async Task<IActionResult> GetCountryDataById(int id)
        {
            var list = await _CountryService.GetCountryBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("CountryDeleteById")]
        public async Task<IActionResult> CountryDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _CountryService.CountryDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
