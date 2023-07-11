using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ozone.Infrastructure;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Ozone.Application.DTOs;

namespace Ozone.WebApi.Controllers 
{
    [Route("api/[controller]")]
    public class TenantUserManagementController : BaseApiController
    {
    #region Fields
    private readonly IMapper _mapper;
    private readonly ITenanatUserManagementService _tenantUserManagementService;
        #endregion

        #region Ctor
        public TenantUserManagementController(
            IMapper mapper,
            ITenanatUserManagementService tenantUserManagementService
            )
        {
            this._mapper = mapper;
            this._tenantUserManagementService = tenantUserManagementService;
        }
        #endregion

        #region Methods
        [Route("userMaintenance")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var List = await _tenantUserManagementService.GetAllUsers(queryParameter);
            return new JsonResult(List);
        }

        [Route("userMaintenance/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(long id)
        {
            var List = await _tenantUserManagementService.GetUserById(id);
            return new JsonResult(List);
        }

        [Route("userMaintenance/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateUser(long id, UserDataWithFilesModel user)
        {
            var List = await _tenantUserManagementService.UpdateUserManagement(id, user);
            return new JsonResult(List);
        }

        [Route("userMaintenance")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDataWithFilesModel user)
        {
            var List = await _tenantUserManagementService.CreateUserManagement(user);
            return new JsonResult(List);
        }

        #endregion
    }
}
