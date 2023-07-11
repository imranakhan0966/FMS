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
    public class ProjectAmountController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IProjectAmountService _ProjectAmountService;
        private readonly IJwtAuthManager _jwtAuthManager;

       
        public ProjectAmountController(
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IProjectAmountService _ProjectAmountService,
            IJwtAuthManager jwtAuthManager
            )
        {

            _configuration = configuration;
            this._userSessionService = userSessionService;
            this._ProjectAmountService = _ProjectAmountService;
            this._jwtAuthManager = jwtAuthManager;
        }




        [Route("GetAllAgency")]
        [HttpGet]
        public async Task<IActionResult> GetAllAgency()
        {
            var List = await _ProjectAmountService.GetAllAgency();
            return new JsonResult(List);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ProjectAmountModel input)
        {
            var result = await _ProjectAmountService.Create(input);
            return Ok(new Response { Status = result, Message = result });
        }

        [Route("GetPagedProjectAmount")]
        [HttpPost]
        public async Task<IActionResult> GetPagedProjectAmount(PagedResponseModel model)
        {
            var list = await _ProjectAmountService.GetPagedProjectAmountResponse(model);
            return new JsonResult(list);
        }

        [Route("GetProjectAmountDataById")]
        [HttpGet]
        public async Task<IActionResult> GetProjectAmountDataById(int id)
        {
            var list = await _ProjectAmountService.GetProjectAmountBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("ProjectAmountDeleteById")]
        public async Task<IActionResult> ProjectAmountDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _ProjectAmountService.ProjectAmountDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
