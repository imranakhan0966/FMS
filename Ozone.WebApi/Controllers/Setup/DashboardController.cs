using Microsoft.AspNetCore.Mvc;
using Ozone.Application.DTOs;
using Ozone.Infrastructure.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {

        IClientAuditVisitService _clientAuditService;

        public DashboardController(IClientAuditVisitService clientAuditVisitService)
        {
            this._clientAuditService = clientAuditVisitService;
        }

        
      
        [Route("GetDashboardData")]
        [HttpPost]
        public async Task<IActionResult> GetDashboardData(long id, PagedResponseModel model)
        {
            var list = await _clientAuditService.ProjectStatus(id,model );
            return new JsonResult(list);


        }
    }
}
