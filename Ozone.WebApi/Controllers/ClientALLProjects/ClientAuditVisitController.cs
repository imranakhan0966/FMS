
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


using Ozone.Infrastructure.Shared.Services;

using System.Threading.Tasks;

using Ozone.Application.DTOs;

using Ozone.Application.Interfaces.Service;

using System.IO;
using Ozone.Infrastructure;
using System.Collections.Generic;

namespace Ozone.WebApi.Controllers.ClientALLProjects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAuditVisitController : BaseApiController
    {
        private readonly IConfiguration _configuration;

    IAllDropdownService _AllDropdownService;
    ISecUserSessionService _userSessionService;
        IClientAuditVisitService _clientAuditVisitService;
        IAuditReportService _auditReportService;
        private readonly IJwtAuthManager _jwtAuthManager;


    //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
    public ClientAuditVisitController(
        // UserService userService,
        IConfiguration configuration,

        ISecUserSessionService userSessionService,
        IClientAuditVisitService clientAuditVisitService,
        IAuditReportService auditReportService,
        IJwtAuthManager jwtAuthManager,
        IAllDropdownService allDropdownService
        )
    {
        //this.userManager = userManager;
        // this._userService = userService;
        _configuration = configuration;
        this._AllDropdownService = allDropdownService;
        this._userSessionService = userSessionService;
        this._clientAuditVisitService = clientAuditVisitService;
        this._jwtAuthManager = jwtAuthManager;
            this._auditReportService = auditReportService;
    }



        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ClientAuditVisitModel input)
        {

            var result = await _clientAuditVisitService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedClientAuditVisitResponse")]
        [HttpPost]
        public async Task<IActionResult> GetPagedClientAuditVisitResponse(long id,PagedResponseModel model)
        {
            var list = await _clientAuditVisitService.GetPagedClientAuditVisitResponse(id,model);
            return new JsonResult(list);
        }

        [Route("GetClientAuditVisitBYId")]
        [HttpGet]
        public async Task<IActionResult> GetClientAuditVisitBYId(int id)
        {
            var list = await _clientAuditVisitService.GetClientAuditVisitBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("ClientAuditVisitDeleteById")]
        public async Task<IActionResult> ClientAuditVisitDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _clientAuditVisitService.ClientAuditVisitDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }


        [Route("GetALLVisitType")]
        [HttpGet]
        public async Task<IActionResult> GetALLVisitType()
        {
            var List = await _AllDropdownService.GetALLVisitType();
            return new JsonResult(List);
        }
        [Route("GetALLVisitStatus")]
        [HttpGet]
        public async Task<IActionResult> GetALLVisitStatus()
        {
            var List = await _AllDropdownService.GetALLVisitStatus();
            return new JsonResult(List);
        }
        [Route("GetAllProjectCode")]
        [HttpGet]
        public async Task<IActionResult> GetAllProjectCode()
        {
            var List = await _AllDropdownService.GetAllProjectCode();
            return new JsonResult(List);
        }
        [Route("GetProjectCodeById")]
        [HttpGet]
        public async Task<IActionResult> GetProjectCodeById(long id)
        {
            var List = await _AllDropdownService.GetProjectCodeById(id);
            return new JsonResult(List);
        }
        [Route("AuditPlan")]
        [HttpPost]
        public async Task<IActionResult> AuditPlan(long id,PagedResponseModel model)
        {
            var list = await _clientAuditVisitService.AuditPlan(id,model);
            return new JsonResult(list);
        }
        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadAuditPlan")]
        public async Task<IActionResult> DownloadAuditPlan(long id)
        {

            var result = await _clientAuditVisitService.DownloadAuditPlan(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.AuditPlanFilePath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.AuditPlanContentType;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }
        [Route("CreateAuditReport")]
        [HttpPost]
        public async Task<IActionResult> CreateAuditReport([FromForm] AuditVisitReportMasterModel input)
        {

            var result = await _auditReportService.CreateAuditReport(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedAuditReport")]
        [HttpPost]
        public async Task<IActionResult> GetPagedAuditReport(PagedResponseModel model)
        {
            var list = await _auditReportService.GetPagedAuditReportResponse(model);
            return new JsonResult(list);
        }
        //[Route("GetPagedAuditReportById")]
        //[HttpPost]
        //public async Task<IActionResult> GetPagedAuditReportById(long id,PagedResponseModel model)
        //{
        //    var list = await _auditReportService.GetPagedAuditReportResponseById(id,model);
        //    return new JsonResult(list);
        //}
        [Route("GetPagedAuditReportById")]
        [HttpPost]
        public async Task<IActionResult> GetPagedAuditReportById(long id, PagedResponseModel model)
        {
            var list = await _auditReportService.GetPagedAuditReportDetailById(id, model);
            return new JsonResult(list);
        }
        [Route("GetAuditReportById")]
        [HttpGet]
        public async Task<IActionResult> GetAuditReportById(int id)
        {
            var list = await _auditReportService.AuditReportBYId(id);
            return new JsonResult(list);


        }

        [HttpPost]
        [Route("AuditReportDeleteById")]
        public async Task<IActionResult> AuditReportDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _auditReportService.AuditReportDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadAuditReport")]
        public async Task<IActionResult> DownloadAuditReport(long id)
        {

            var result = await _auditReportService.DownloadAuditReport(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.DocumentFilePath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.DocumentContentType;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }

        [Route("GetALLAuditDoucmentsType")]
        [HttpGet]
        public async Task<IActionResult> GetALLAuditDoucmentsType()
        {
            var List = await _AllDropdownService.GetAllAuditDocumentsType();
            return new JsonResult(List);
        }

        [Route("GetPagedAuditReportDetail")]
        [HttpPost]
        public async Task<IActionResult> GetPagedAuditReportDetail(long id,PagedResponseModel model)
        {
            var list = await _auditReportService.GetPagedAuditReportDetailById(id,model);
            return new JsonResult(list);
        }

        //[Route("AuditComplete")]
        //[HttpPost]
        //public async Task<IActionResult> AuditComplete(long id)
        //{
        //    var result = await _clientAuditVisitService.AuditComplete(id);
        //    return Ok(new Response { Status = result, Message = result });
        //}

        [Route("AuditComplete")]
        [HttpPost]
        public async Task<IActionResult> AuditComplete(ClientAuditVisitModel input)
        {
            var result = await _clientAuditVisitService.AuditComplete(input);
            return Ok(new Response { Status = result, Message = result });
        }


        //[HttpPost]
        //[Route("SubmitForReview")]
        ////  [Authorize]
        //public async Task<IActionResult> SubmitForReview(long id, long loginUserId)
        //{
        //    // SecUserService secuserservice = new SecUserService();
        //    var result = await _clientAuditVisitService.SubmitForReview(id, loginUserId);
        //    return Ok(new Response { Status = result, Message = result });

        //}

        [HttpPost]
        [Route("QCDocumentsList")]
        public async Task<IActionResult> QCDocumentsList(long id,PagedResponseModel model)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _auditReportService.QCDocumentsList(id,model);
            return new JsonResult(result);

        }
        [HttpGet]
        [Route("QCHostory")]
        public async Task<IActionResult> QCHostory(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _auditReportService.QcHistory(id);
            return new JsonResult(result);

        }


        //[Route("AddCommentList")]
        //[HttpPost]
        //public async Task<IActionResult> AddCommentList([FromForm]List<QCHistoryModelTow> QCHistoryModel)
        //{
        //   List< QCHistoryModel> QC = new List<QCHistoryModel>();
        //    var result = await _auditReportService.AddCommentList(QC);
        //    return Ok(new Response { Status = result, Message = result });



        //}

        [Route("AddCommentList")]
        [HttpPost]
        public async Task<IActionResult> AddCommentList(List<QCHistoryModel> QC)
        {
            //List<QCHistoryModel> QC = new List<QCHistoryModel>();
            var result = await _auditReportService.AddCommentList(QC);
            return Ok(new Response { Status = result, Message = result });



        }


        [Route("AddMasterCommentList")]
        [HttpPost]
        public async Task<IActionResult> AddMasterCommentList(QCDocumentsListModel input)
        {
            var result="Farooq";
            //var result = await _auditReportService.AddCommentList(input);
            return Ok(new Response { Status = result, Message = result });



        }
        [Route("AddComment")]
        [HttpPost]
        public async Task<IActionResult> AddComment(QCHistoryModel input)
        {

            var result = await _auditReportService.AddComment(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [HttpPost]
        [Route("QCCommentsDeleteById")]
        public async Task<IActionResult> QCCommentsDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _auditReportService.QCCommentsDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
        [Route("GetAllQcStatus")]
        [HttpGet]
        public async Task<IActionResult> GetAllQcStatus()
        {
            var List = await _auditReportService.GetAllQcStatus();
            return new JsonResult(List);
        }
        [HttpPost]
        [Route("AuditSubmitForReview")]
        //  [Authorize]
        public async Task<IActionResult> AuditSubmitForReview(long id, long loginUserId)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _auditReportService.SubmitForReview(id, loginUserId);
            return Ok(new Response { Status = result, Message = result });

        }
        [Route("GetAllAdminList")]
        [HttpGet]
        public async Task<IActionResult> GetAllAdminList()
        
        {
            var List = await _AllDropdownService.GetAllAdminList();
            return new JsonResult(List);
        }
        [Route("GetAllTechnicalExpert")]
        [HttpGet]
        public async Task<IActionResult> GetAllTechnicalExpert(long id)

        {
            var List = await _AllDropdownService.GetAllTechnicalExpert(id);
            return new JsonResult(List);
        }

        [Route("GetALLVisitLevel")]
        [HttpGet]
        public async Task<IActionResult> GetALLVisitLevel()
        {
            var List = await _AllDropdownService.GetALLVisitLevel();
            return new JsonResult(List);
        }
    }
}
