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
using Ozone.Application.Interfaces;
using Ozone.Application.DTOs.Projects;

namespace Ozone.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAmountReportsController : BaseApiController
    {
        IProjectAmountReportsService _ProjectAmountReportsService;
        public ProjectAmountReportsController
        (
           IProjectAmountReportsService ProjectAmountReportsService
        )

        {
            this._ProjectAmountReportsService = ProjectAmountReportsService;
        }


        [Route("GetPagedProjectLedger")]
        [HttpPost]
        public async Task<IActionResult> GetPagedProjectLedger(PagedResponseModel model)
        {
            var list = await _ProjectAmountReportsService.GetPagedProjectLedger(model);
            return new JsonResult(list);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ProjectLedgerDetailModel input)
        {

            var result = await _ProjectAmountReportsService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }


        [Route("GetAllAgency")]
        [HttpGet]
        public async Task<IActionResult> GetAllAgency()
        {
            var List = await _ProjectAmountReportsService.GetAllAgency();
            return new JsonResult(List);

        }
        [Route("GetPagedProjectLedgerDetail")]
        [HttpPost]
        public async Task<IActionResult> GetPagedProjectLedgerDetail(long id,PagedResponseModel model)
        {
            var list = await _ProjectAmountReportsService.GetPagedProjectLedgerDetail(id,model);
            return new JsonResult(list);
        }

    }
}
