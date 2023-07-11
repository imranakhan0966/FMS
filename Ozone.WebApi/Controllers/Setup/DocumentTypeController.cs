using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Ozone.Application.DTOs;
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
    public class DocumentTypeController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IDocumentTypeService _DocumentTypeService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public DocumentTypeController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IDocumentTypeService DocumentTypeService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._DocumentTypeService = DocumentTypeService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(DocumentsTypeModel input)
        {

            var result = await _DocumentTypeService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedDocumentType")]
        [HttpPost]
        public async Task<IActionResult> GetPagedModule(PagedResponseModel model)
        {
            var list = await _DocumentTypeService.GetPagedDocumentsTypeResponse(model);
            return new JsonResult(list);
        }

        [Route("GetDocumentTypeDataById")]
        [HttpGet]
        public async Task<IActionResult> GetDocumentTypeDataById(int id)
        {
            var list = await _DocumentTypeService.GetDocumentsTypeBYId(id);
            return new JsonResult(list);


        }
        [HttpPost]
        [Route("DocumentTypeDeleteById")]
        public async Task<IActionResult> DocumentTypeDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _DocumentTypeService.DocumentTypeDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

       
    }
}
