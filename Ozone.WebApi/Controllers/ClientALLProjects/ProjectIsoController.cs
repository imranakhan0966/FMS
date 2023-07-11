

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


using Ozone.Infrastructure.Shared.Services;

using System.Threading.Tasks;

using Ozone.Application.DTOs;

using Ozone.Application.Interfaces.Service;

using System.IO;
using Ozone.Infrastructure;


namespace Ozone.WebApi.Controllers.ClientALLProjects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectIsoController : BaseApiController
    {
        private readonly IConfiguration _configuration;

        IAllDropdownService _AllDropdownService;
        ISecUserSessionService _userSessionService;
        IProjectIsoService _projectIsoService;
        private readonly IJwtAuthManager _jwtAuthManager;


        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public ProjectIsoController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            IProjectIsoService projectIsoService,
            IJwtAuthManager jwtAuthManager,
            IAllDropdownService allDropdownService
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            this._AllDropdownService = allDropdownService;
            this._userSessionService = userSessionService;
            this._projectIsoService = projectIsoService;
            this._jwtAuthManager = jwtAuthManager;
        }

        [Route("ProjectIsoCreateWithFile")]
        [HttpPost]
        public async Task<IActionResult> ProjectIsoCreateWithFile([FromForm] ProjectIsoModel input)
        {

            var result = await _projectIsoService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        //[Route("GetPagedProjectSA8000")]
        //[HttpPost]
        //public async Task<IActionResult> GetPagedProjectSA8000(PagedResponseModel model)
        //{
        //    var list = await _projectSlcpService.getp(model);
        //    return new JsonResult(list);
        //}
        [Route("GetProjectIsoBYId")]
        [HttpGet]
        public async Task<IActionResult> GetProjectIsoBYId(long id)
        {
            var list = await _projectIsoService.GetProjectIsoBYId(id);
            return new JsonResult(list);


        }


        [HttpPost]
        [Route("ProjectIsoDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> ProjectIsoDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _projectIsoService.ProjectIsoDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadApplicationForm")]
        public async Task<IActionResult> DownloadApplicationForm(long id)
        {

            var result = await _projectIsoService.DownloadFile(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.ApplicationFormPath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.ApplicationContentType;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }


        [Route("GetAllVerificationType")]
        [HttpGet]
        public async Task<IActionResult> GetAllVerificationType()
        {
            var List = await _AllDropdownService.GetAllVerificationType();
            return new JsonResult(List);
        }
        [Route("GetAllProjectType")]
        [HttpGet]
        public async Task<IActionResult> GetAllProjectType()
        {
            var List = await _AllDropdownService.GetAllProjectType();
            return new JsonResult(List);
        }
        [Route("GetALLServicesType")]
        [HttpGet]
        public async Task<IActionResult> GetALLServicesType()
        {
            var List = await _AllDropdownService.GetALLServicesType();
            return new JsonResult(List);
        }



        //[Route("GetALLCompletedModule")]
        //[HttpGet]
        //public async Task<IActionResult> GetALLCompletedModule()
        //{
        //    var List = await _AllDropdownService.GetALLCompletedModule();
        //    return new JsonResult(List);
        //}
        [Route("GetALLAccreditation")]
        [HttpGet]
        public async Task<IActionResult> GetALLAccreditation()
        {
            var List = await _AllDropdownService.GetAllAccreditation();
            return new JsonResult(List);
        }

        [Route("GetALLStageCertification")]
        [HttpGet]
        public async Task<IActionResult> GetALLStageCertification()
        {
            var List = await _AllDropdownService.GetAllStageCertification();
            return new JsonResult(List);
        }



        [Route("GetPagedPrjectRemarks")]
        [HttpPost]
        public async Task<IActionResult> GetPagedPrjectRemarks(PagedResponseModel model)
        {
            var list = await _AllDropdownService.GetPagedProjectRemarks(model);
            return new JsonResult(list);
        }

        [HttpPost]
        [Route("CreateApproval")]
        public async Task<IActionResult> CreateApproval(ProjectRemarksHistoryModel input)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _projectIsoService.Approval(input);
            return Ok(new Response { Status = result, Message = result });

        }
        [Route("GetALLRequestOfSite")]
        [HttpGet]
        public async Task<IActionResult> GetALLRequestOfSite()
        {
            var List = await _AllDropdownService.GetALLRequestOfSite();
            return new JsonResult(List);
        }


        [Route("GetALLProjectStatus")]
        [HttpGet]
        public async Task<IActionResult> GetALLProjectStatus(long id)
        {
            var List = await _AllDropdownService.GetALLProjectStatus(id);
            return new JsonResult(List);
        }
        [HttpPost]
        [Route("SubmitForReview")]
        //  [Authorize]
        public async Task<IActionResult> SubmitForReview(long id, long loginUserId)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _projectIsoService.SubmitForReview(id, loginUserId);
            return Ok(new Response { Status = result, Message = result });

        }

        [Route("GetAllClientSites")]
        [HttpGet]
        public async Task<IActionResult> GetAllClientSites(long id)
        {
            var List = await _AllDropdownService.GetAllClientSites(id);
            return new JsonResult(List);
        }


        [Route("ContractSubmit")]
        [HttpPost]
        public async Task<IActionResult> ContractSubmit([FromForm] ClientProjectModel input)
        {

            var result = await _projectIsoService.ContractSubmit(input);
            return Ok(new Response { Status = result, Message = result });



        }
        [Route("ContractApproval")]
        [HttpPost]
        public async Task<IActionResult> ContractApproval([FromForm] ClientProjectModel input)
        {

            var result = await _projectIsoService.ContractApproval(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadContract")]
        public async Task<IActionResult> DownloadContract(long id)
        {

            var result = await _projectIsoService.downloadContract(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.ContractFilePath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.ContractFileContent;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }
    }
}