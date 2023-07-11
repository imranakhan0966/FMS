//using Ozone.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecPolicyController : BaseApiController
    {
      //  ISecPolicyService _secPolicyRepo;

        //public SecPolicyController(ISecPolicyService secPolicyRepo)
        //{
        //    this._secPolicyRepo = secPolicyRepo;
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetPassword()
        //{
        //    var passwordpolicy = await _secPolicyRepo.GetPasswordComplexityRegexPolicy();
        //    return new JsonResult(passwordpolicy);
        //}
    }
}
