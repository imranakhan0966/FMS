using AutoMapper;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Security;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Parameters;
//using Ozone.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecRoleController : BaseApiController
    {
       
        ISecRoleService _secRoleService;
        private readonly IMapper _mapper;
       public SecRoleController(
           IMapper mapper,
           ISecRoleService secRoleService
          
           )
        {
          
            this._secRoleService = secRoleService;
            this._mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> CreateSecRoleForm(SecRoleFormPagedModel model)
        {
            var result = await _secRoleService.CreateSecRoleService(model);
            return Ok(new Response { Status = result, Message = result });

        }
        [Route("CreatePermissions")]
        [HttpPost]
        public async Task<IActionResult> CreateSecRolePermissions(SecRoleModelUpdate model)
        {
            
            var result =  await _secRoleService.CreateSecRoleForm(model);
            return Ok(new Response { Status = result, Message = result });

        }
        [Route("GetPagedRoles")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserResponse(PagedResponseModel model)
        {
            var list = await _secRoleService.GetPagedSecRoleReponse(model);
            return new JsonResult(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetPagedSecRoleFormReponse(int pageNumber, int pageSize, string orderBy, string fields)
        {
            var parameter = new QueryParameter()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                OrderBy = orderBy,
                Fields = fields
            };

            var RoleFormPagesList = await _secRoleService.GetPagedRoleFormReponseService(parameter);
            return new JsonResult(RoleFormPagesList);
        }
        [Route("GetSecRole")]
        [HttpGet]
        public async Task<IActionResult> GetSecRole(long id)
        {
            var RolesList = await _secRoleService.GetAllRoles(id);
            return new JsonResult(RolesList);
        }
        [Route("GetUserType")]
        [HttpGet]
        public async Task<IActionResult> GetUserType(long id)
        {
            var UserTypeList = await _secRoleService.GetAllUserType(id);
            return new JsonResult(UserTypeList);
        }

        [Route("GetSecRolePermission")]
        [HttpGet]
        public async Task<IActionResult> GetSecRolePermission()
        {
            var RolesList = await _secRoleService.GetAllSecRoleForm();
            return new JsonResult(RolesList);
        }

        [Route("GetAllSecForm")]
        [HttpGet]
        public async Task<IActionResult> GetPagedSecFormReponse(int pageNumber, int pageSize, string orderBy, string fields)
        {
            var parameter = new QueryParameter()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                OrderBy = orderBy,
                Fields = fields
            };

            var SecFormPagesList = await _secRoleService.GetPagedSecFormReponseService(parameter);
            return new JsonResult(SecFormPagesList);
        }
        [Route("GetSecRoleForm")]
        [HttpGet]
        public async Task<IActionResult> GetAllPagedSecRoleFormReponse(int pageNumber, int pageSize, string orderBy, string fields)
        {
            var parameter = new QueryParameter()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                OrderBy = orderBy,
                Fields = fields
            };

            var SecFormPagesList = await _secRoleService.GetSecRoleForm(parameter);
            return new JsonResult(SecFormPagesList);
        }
        [Route("UpdateSecRoleForm")]
        [HttpPut]
        public async Task<IActionResult> Update(SecRoleModelUpdate input)
        {
            var result = await _secRoleService.Update(input);
            return Ok(new Response { Status = result, Message = result });
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var list = await _secRoleService.GetAllPermissionsByRoleId(id);
            return new JsonResult(list);
        }
        [HttpPost]
        [Route("Authorize")]
        public async Task<IActionResult> AuthorizeRole(long id, string Remarks)
        {
            await _secRoleService.AuthorizeRole(id, Remarks);
            return Ok(new Response { Status = "Success", Message = "Successfully Authorized!" });
        }

        [HttpPost]
        [Route("Reject")]
        public async Task<IActionResult> RejectRole(long id, string Remarks)
        {
            await _secRoleService.RejectRole(id, Remarks);
            return Ok(new Response { Status = "Success", Message = "Successfully Rejected!" });
        }
        [Route("GetCities")]
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var List = await _secRoleService.GetAllCities();
            return new JsonResult(List);
        }
        [Route("GetCountries")]
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var List = await _secRoleService.GetAllCountry();
            return new JsonResult(List);
        }



        [Route("GetPrefix")]
        [HttpGet]
        public async Task<IActionResult> GetPrefix()
        {
            var List = await _secRoleService.GetAllPrefix();
            return new JsonResult(List);
        }
        [Route("GetState")]
        [HttpGet]
        public async Task<IActionResult> GetState()
        {
            var List = await _secRoleService.GetAllState();
            return new JsonResult(List);
        }
        [Route("GetActiveStatus")]
        [HttpGet]
        public async Task<IActionResult> GetActiveState()
        {
            var List = await _secRoleService.GetAllActiveStatus();
            return new JsonResult(List);
        }

    }
}
