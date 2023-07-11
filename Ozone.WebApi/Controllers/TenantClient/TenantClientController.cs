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
using Ozone.Infrastructure.Persistence.Models;
using Ozone.Infrastructure.Shared.Services;

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TenantClientController : BaseApiController
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly ITenantClientService _tenantClientService;
        private readonly ITenanatUserManagementService _tenantUserManagementService;
        private readonly OzoneContext _context;
        #endregion

        #region Ctor
        public TenantClientController(
            IMapper mapper,
            ITenanatUserManagementService tenantUserManagementService,
            ITenantClientService tenantClientService,
            OzoneContext context
            )
        {
            this._tenantUserManagementService = tenantUserManagementService;
            this._context = context;
            this._mapper = mapper;
            this._tenantClientService = tenantClientService;
        }
        #endregion

        #region Methods

        #region Client
        [Route("client")]
        [HttpGet]
        public async Task<IActionResult> GetAllClients([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var List = await _tenantClientService.GetAllClient(queryParameter);
            return new JsonResult(List);
        }

        [Route("client")]
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientModel client)
        {
            var List = await _tenantClientService.InsertClient(client);
            if (List.Contains("Successfully Inserted"))
            {
                var chkClient = await Task.Run(() => _context.Client.Where(x => x.Name == client.Name && x.Email == client.Email).FirstOrDefault());
                if (chkClient != null)
                {
                    UserDataWithFilesModel user = new UserDataWithFilesModel();
                    user.Address1 = client.Address1;
                    user.Address2 = client.Address2;
                    user.ParentUserId = null;
                    user.UserName = client.Email;
                    user.ConfirmPassword = client.Password;
                    user.Password = client.Password;
                    user.Email = client.Email;
                    user.RoleId = 24;
                    user.StateId = client.StateId;
                    user.CountryId = client.CountryId;
                    user.CityId = client.CityId;
                    user.FullName = client.Name;
                    user.FirstName = null;
                    user.LastName = null;
                    user.IsActive = true;
                    user.Mobile = client.MobileNumber;
                    user.Telephone = client.PersonContactNumber;
                    user.ClientId = chkClient.Id;
                    user.EmailForgotPassword = client.Email;
                    var list2 = await _tenantUserManagementService.CreateUserManagement(user);
                }
            }
            return new JsonResult(List);
        }

        [Route("client/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetClientById(long id)
        {
            var List = await _tenantClientService.GetClientById(id);
            return new JsonResult(List);
        }

        [Route("client/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateClient(long id, ClientModel client)
        {
            var List = await _tenantClientService.UpdateClient(id, client);
            return new JsonResult(List);
        }
        #endregion

        #endregion
    }
}
