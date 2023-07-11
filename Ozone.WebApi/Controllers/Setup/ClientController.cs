using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Ozone.Infrastructure.Shared.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ozone.Infrastructure.Persistence;
using Ozone.Application.DTOs;
//using Ozone.Application.Interfaces.Service;
using Ozone.Infrastructure.Shared;
using Ozone.Infrastructure;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Ozone.Infrastructure.Persistence.Models;
using System.Security.Cryptography;
using System.Collections.Concurrent;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Interfaces;
using Ozone.Application;
using System.IO;
using AutoMapper;


namespace Ozone.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseApiController
    {
        private readonly IConfiguration _configuration;

        IAllDropdownService _AllDropdownService;
        private readonly IMapper _mapper;
        IClientService _ClientService;
        IClientSitesService _ClientSitesService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public ClientController(IMapper mapper,
            // UserService userService,
            IConfiguration configuration,

            IAllDropdownService allDropdownService,
            IClientService clientService,
                IClientSitesService ClientSitesService,
            IJwtAuthManager jwtAuthManager
            )
        {
            this._mapper = mapper;
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._ClientService = clientService;
            this._ClientSitesService = ClientSitesService;
            this._jwtAuthManager = jwtAuthManager;
            this._AllDropdownService = allDropdownService;
        }
        [Route("GetPagedClient")]
        [HttpPost]
        public async Task<IActionResult> GetPagedClient(long id, PagedResponseModel model)
        {
            var list = await _ClientService.GetPagedClient(id, model);
            return new JsonResult(list);
        }

        [Route("GetClientDataById")]
        [HttpGet]
        public async Task<IActionResult> GetClientDataById(int id)
        {
            var list = await _ClientService.GetClientBYId(id);
            return new JsonResult(list);


        }

        [Route("CreateClient")]
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientModel input)
        {

            var result = await _ClientService.CreateClient(input);
            return Ok(new Response { Status = result, Message = result });


        }
        [HttpPost]
        [Route("ClientDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> ClientDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _ClientService.ClientDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }



        [Route("CreateClientSites")]
        [HttpPost]
        public async Task<IActionResult> CreateClientSites(ClientSitesModel input)
        {

            var result = await _ClientSitesService.CreateClientSites(input);
            return Ok(new Response { Status = result, Message = result });


        }

        [Route("GetPagedClientSites")]
        [HttpPost]
        public async Task<IActionResult> GetPagedClientSites(PagedResponseModel model)
        {
            var list = await _ClientSitesService.GetPagedClientSites(model);
            return new JsonResult(list);
        }

        [Route("GetPagedClientAllProject")]
        [HttpPost]
        public async Task<IActionResult> GetPagedClientAllProject(long id,PagedResponseModel model)
        {
            var list = await _ClientSitesService.GetPagedClientProjects(id,model);
            return new JsonResult(list);
        }

        [Route("GetPagedAllProject")]
        [HttpPost]
        public async Task<IActionResult> GetPagedAllProject(long id, PagedResponseModel model)


        {
            var list = await _ClientSitesService.GetPagedAllProjects(id, model);
            //var list1 = await _ClientSitesService.GetPagedAllProjects(id, model);
            return new JsonResult(list);
        }

        [Route("GetPagedAllAudits")]
        [HttpPost]
        public async Task<IActionResult> GetPagedAllAudits(long id, PagedResponseModel model)


        {
            var list = await _ClientSitesService.GetPagedAllAudits(id, model);
            //var list1 = await _ClientSitesService.GetPagedAllProjects(id, model);
            return new JsonResult(list);
        }
        [Route("GetProjectFormUrlById")]
        [HttpGet]
        public async Task<IActionResult> GetProjectFormUrlById(long id)
        {
            var list = await _ClientSitesService.GetProjectUrlBYId(id);
            return new JsonResult(list);


        }

        [Route("GetSiteById")]
        [HttpGet]
        public async Task<IActionResult> GetSiteById(long id)
        {
            var list = await _ClientSitesService.GetClientSitesBYId(id);
            return new JsonResult(list);


        }
        [Route("GetALLClients")]
        [HttpGet]
        public async Task<IActionResult> GetALLClients(long id)
        {
            var list = await _AllDropdownService.GetALLClients(id);
            return new JsonResult(list);


        }

        
        [Route("GetAuditorByStandardId")]
        [HttpPost]
        public async Task<IActionResult> GetAuditorByStandardId(UserStandardModel input)
        {
            var list = await _ClientService.GetAuditorByStandardId(input.Id, input.OrganizationId);
            return new JsonResult(list);


        }

        [Route("GetLeadAuditorByStandardId")]
        [HttpPost]
        public async Task<IActionResult> GetLeadAuditorByStandardId(UserStandardModel input)
        {
            var list = await _ClientService.GetLeadAuditorByStandardId(input.Id, input.OrganizationId);
            return new JsonResult(list);


        }
        [Route("GetReviewerByStandardId")]
        [HttpPost]
        public async Task<IActionResult> GetReviewerByStandardId(UserStandardModel input)
        {
            var list = await _ClientService.GetReviewerByStandardId(input.Id);
            return new JsonResult(list);


        }
        [HttpPost]
        [Route("ClientSitesDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> ClientSitesDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _ClientSitesService.ClientSitesDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
        //[Route("GetClientfullDataById")]
        //[HttpGet]
        //public async Task<IActionResult> GetClientfullDataById(int id)
        //{
        //    var list = await _ClientService.GetClientBYId(id);
        //    return new JsonResult(list);


        //}

        [Route("GetReviewerByStandard")]
        [HttpPost]
        public async Task<IActionResult> GetReviewerByStandard(UserStandardModel input)
        {
           var list = await _ClientService.GetReviewerByStandard(input.StandardId, input.UserId);
            return new JsonResult(list);


        }

    }
}
