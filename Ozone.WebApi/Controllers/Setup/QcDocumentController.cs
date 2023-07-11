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
    public class QcDocumentController : BaseApiController
    {
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        IQcDocumentService _QcDocumentService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public QcDocumentController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IQcDocumentService QcDocumentService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._QcDocumentService = QcDocumentService;
            this._jwtAuthManager = jwtAuthManager;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(QCDocumentsListModel input)
        {

            var result = await _QcDocumentService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedQcDocument")]
        [HttpPost]
        public async Task<IActionResult> GetPagedQcDocument(PagedResponseModel model)
        {
            var list = await _QcDocumentService.GetPagedQcDocumentResponse(model);
            return new JsonResult(list);
        }

        [Route("GetQcDocumentById")]
        [HttpGet]
        public async Task<IActionResult> GetQcDocumentById(int id)
        {
            var list = await _QcDocumentService.GetQcDocumentBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("QcDocumentDeleteById")]
        public async Task<IActionResult> QcDocumentDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _QcDocumentService.QcDocumentDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
    }
}

