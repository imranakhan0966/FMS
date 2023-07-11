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
    public class ConsultantController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IConsultantService _ConsultantService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public ConsultantController(
            IConfiguration configuration,
            ISecUserSessionService userSessionService,
            IConsultantService ConsultantService,
            IJwtAuthManager jwtAuthManager
            )
        {
            _configuration = configuration;
            this._userSessionService = userSessionService;
            this._ConsultantService = ConsultantService;
            this._jwtAuthManager = jwtAuthManager;
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ConsultantModel input)
        {
            var result = await _ConsultantService.Create(input);
            return Ok(new Response { Status = result, Message = result });
        }



        [Route("GetPagedConsultantResponse")]
        [HttpPost]
        public async Task<IActionResult> GetPagedConsultant(PagedResponseModel model)
        {
            var list = await _ConsultantService.GetPagedConsultantResponse(model);
            return new JsonResult(list);
        }


        [Route("GetConsultantDataById")]
        [HttpGet]
        public async Task<IActionResult> GetConsultantDataById(int id)
        {
            var list = await _ConsultantService.GetConsultantBYId(id);
            return new JsonResult(list);
        }



        [HttpPost]
        [Route("ConsultantDeleteById")]
        public async Task<IActionResult> ConsultantDeleteById(long id)
        {
            var result = await _ConsultantService.ConsultantDeleteById(id);
            return Ok(new Response { Status = result, Message = result });
        }
    }
}
