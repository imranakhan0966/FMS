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
    public class AgencyController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        private readonly IMapper _mapper;
        IAgensyService _AgensyService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public AgencyController(IMapper mapper,
            // UserService userService,
            IConfiguration configuration,


            IAgensyService agensyService,
            IJwtAuthManager jwtAuthManager
            )
        {
            this._mapper = mapper;
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
        
            this._AgensyService = agensyService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("GetPagedAgency")]
        [HttpPost]
        public async Task<IActionResult> GetPagedAgency(PagedResponseModel model)
        {
            var list = await _AgensyService.GetPagedAgency(model);
            return new JsonResult(list);
        }
        [Route("GetAgencyDataById")]
        [HttpGet]
        public async Task<IActionResult> GetAgrncyDataById(int id)
        {
            var list = await _AgensyService.GetAgencyBYId(id);
            return new JsonResult(list);


        }

        [Route("CreateAgency")]
        [HttpPost]
        public async Task<IActionResult> CreateAgency(OrganizationModel input)
        {
           
            var result = await _AgensyService.CreateAgency(input);
            return Ok(new Response { Status = result, Message = result });


        }
        [HttpPost]
        [Route("AgencyDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> AgencyDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _AgensyService.AgencyDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}
