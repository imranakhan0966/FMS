using Ozone.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController
    {
        IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var depts = await _departmentService.GetAllDepartments();
            return new JsonResult(depts);
        }
    }
}
