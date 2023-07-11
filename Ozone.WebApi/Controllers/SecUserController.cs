using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
//using Ozone.Application.Interfaces.Security;
//using Ozone.Application.Interfaces.Service;
using Ozone.Application.Parameters;
//using Ozone.Domain.Entities;
using Ozone.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ozone.Infrastructure.Shared.Services;
using Ozone.Application.Interfaces.Security;
using System.IO;
using Ozone.Infrastructure;

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecUserController : BaseApiController
    {
        private readonly IMapper _mapper;
        IAllDropdownService _AllDropdownService;
        ISecUserService _secUserService;
        IUserStandardService _UserStandardService;
        IUserSessionHelper _userSession;
        IUserDeclarationService _UserDeclarationService;
        IUserAcademicService _UserAcademicService;
        IUserProfessionalService _UserProfessionalService;
        IUserEmploymentService _UserEmploymentService;
        IUserCPDService _UserCPDService;
        IUserConsultancyService _UserConsultancyService;
        IUserAuditService _UserAuditService;
        IUserAuditorNaceService _UserAuditorNaceService;

        public SecUserController(
            IMapper mapper,
            ISecUserService secUserService,
            IUserSessionHelper userSession,
            IUserStandardService userStandardService,
            IUserDeclarationService userDeclarationService,
           IUserAcademicService userAcademicService,
           IUserProfessionalService userProfessionalService,
           IUserEmploymentService userEmploymentService,
           IUserCPDService userCPDService,
           IUserConsultancyService userConsultancyService,
           IUserAuditService userAuditService,
           IUserAuditorNaceService userAuditorNaceService,
           IAllDropdownService allDropdownService


            )
        {
            this._secUserService = secUserService;
            this._mapper = mapper;
            this._userSession = userSession;
            this._AllDropdownService = allDropdownService;
            this._UserStandardService = userStandardService;
            this._UserDeclarationService = userDeclarationService;
            this._UserAcademicService = userAcademicService;
            this._UserProfessionalService = userProfessionalService;
            this._UserEmploymentService = userEmploymentService;
            this._UserCPDService = userCPDService;
            this._UserConsultancyService = userConsultancyService;
            this._UserAuditService = userAuditService;
            this._UserAuditorNaceService = userAuditorNaceService;
        }


        [Route("GetPagedUser")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserResponse(long id,PagedResponseModel model)
        {
            var list = await _secUserService.GetPagedSecUserReponse(id,model);
            return new JsonResult(list);
        }
        //[HttpGet("GetLocationById")]
        //public async Task<IActionResult> GetUserLocationsById(int id)
        //{
        //    var list = await _secUserService.GetAllLocationsByUserId(id);
        //    return new JsonResult(list);
        //}

        [HttpPost]
        [Route("CreateSecUser")]
       //  [Authorize]
        public async Task<IActionResult> CreateSecUser(SecUserModel input)
        {
           // SecUserService secuserservice = new SecUserService();
               var result = await _secUserService.CreateUser(input);
            return Ok(new Response { Status = result, Message = result });

        }
        [HttpPost]
        [Route("Approval")]
        public async Task<IActionResult> Approval(SecUserModel input)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _secUserService.Approval(input);
            return Ok(new Response { Status = result, Message = result });

        }
        [HttpPost]
        [Route("SubmitForReview")]
        //  [Authorize]
        public async Task<IActionResult> SubmitForReview(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _secUserService.SubmitForReview(id);
            return Ok(new Response { Status = result, Message = result });

        }

        [HttpPost]
        [Route("SubmitForReviewStatus")]
        //  [Authorize]
        public async Task<IActionResult> SubmitForReviewStatus(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserStandardService.SubmitForReviewStatus(id);
            return Ok(new Response { Status = result, Message = result });


        }

        [HttpPost]
        [Route("AuditorNaceSubmitForReviewStatus")]
        //  [Authorize]
        public async Task<IActionResult> AuditorNaceSubmitForReviewStatus(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserAuditorNaceService.AuditorNaceSubmitForReviewStatus(id);
            return Ok(new Response { Status = result, Message = result });

        }

        [Route("CreateUserWithFiles")]
        [HttpPost]
        public async Task<IActionResult> CreateUserWithFiles([FromForm] UserDataWithFilesModel input)
        {
          
            var result = await _secUserService.CreateUserWithFiles(input);
            return Ok(new Response { Status = result, Message = result });

          

        }
        [Route("GetUserDataById")]
        [HttpGet]
        public async Task<IActionResult> GetUserDataById(int id)
        {
            var list = await _secUserService.GetUserDataById(id);
            return new JsonResult(list);


        }
      

        [HttpPost]
        [Route("UserDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> UserDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _secUserService.UserDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

        //UserStandard...
        [Route("UserStandardsCreateWithFile")]
        [HttpPost]
        public async Task<IActionResult> UserStandardsCreateWithFile([FromForm] UserStandardModel input)
        {

            var result = await _UserStandardService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("CreateUserStandard")]
        [HttpPost]
        public async Task<IActionResult> CreateUserStandard([FromForm] UserStandardModel input)
        {

            var result = await _UserStandardService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedUserStandard")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserStandard(PagedResponseModel model)
        {
            var list = await _UserStandardService.GetPagedUserStandardResponse(model);
            return new JsonResult(list);
        }
        [Route("GetUserStandardById")]
        [HttpGet]
        public async Task<IActionResult> GetUserStandardById(int id)
        {
            var list = await _UserStandardService.GetUserStandardBYId(id);
            return new JsonResult(list);


        }
        [HttpPost]
        [Route("UserStandardDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> UserStandardDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserStandardService.UserStandardDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

        [Route("GetAllAuditorType")]
        [HttpGet]
        public async Task<IActionResult> GetAllAuditorType(long id)
        {
            var List = await _UserStandardService.GetAllAuditorType(id);
            return new JsonResult(List);
        }
        [Route("GetAllCourseType")]
        [HttpGet]
        public async Task<IActionResult> GetAllCourseType()
        {
            var List = await _UserStandardService.GetAllCourseType();
            return new JsonResult(List);
        }
        [Route("GetAllApprovalStatus")]
        [HttpGet]
        public async Task<IActionResult> GetAllApprovalStatus()
        {
            var List = await _UserStandardService.GetAllApprovalStatus();
            return new JsonResult(List);
        }
        [Route("GetAllCertification")]
        [HttpGet]
        public async Task<IActionResult> GetAllCertification()
        {
            var List = await _UserStandardService.GetAllCertification();
            return new JsonResult(List);
        }
        [Route("GetAllCertificationBody")]
        [HttpGet]
        public async Task<IActionResult> GetAllCertificationBody()
        {
            var List = await _UserStandardService.GetAllCertificationBody();
            return new JsonResult(List);
        }
        [Route("GetAllAuditType")]
        [HttpGet]
        public async Task<IActionResult> GetAllAuditType()
        {
            var List = await _UserStandardService.GetAllAuditType();
            return new JsonResult(List);
        }
        [Route("GetAllEACode")]
        [HttpGet]
        public async Task<IActionResult> GetAllEACode()
        {
            var List = await _UserConsultancyService.GetAllEACode();
            return new JsonResult(List);
        }
        [Route("GetAllNaceCode")]
        [HttpGet]
        public async Task<IActionResult> GetAllNaceCode()
        {
            var List = await _UserConsultancyService.GetAllNaceCode();
            return new JsonResult(List);
        }
        //User...
        [Route("CreateUserDeclaration")]
        [HttpPost]
        public async Task<IActionResult> CreateUserDeclaration(UserDeclarationModel input)
        {
            var result = await _UserDeclarationService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedUserDeclaration")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserDeclaration(PagedResponseModel model)
        {
            var list = await _UserDeclarationService.GetPagedUserDeclarationResponse(model);
            return new JsonResult(list);
        }
        [Route("GetUserDeclarationById")]
        [HttpGet]
        public async Task<IActionResult> GetUserDeclarationById(int id)
        {
            var list = await _UserDeclarationService.GetUserDeclarationBYId(id);
            return new JsonResult(list);


        }
        [HttpPost]
        [Route("UserDeclarationById")]
        //  [Authorize]
        public async Task<IActionResult> UserDeclarationDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserDeclarationService.UserDeclarationDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
        [Route("GetAllContractType")]
        [HttpGet]
        public async Task<IActionResult> GetAllContractType()
        {
            var List = await _UserDeclarationService.GetAllContractType();
            return new JsonResult(List);
        }


        //User Academic

        [Route("UserAcademicCreateWithFile")]
        [HttpPost]
        public async Task<IActionResult> UserAcademicCreateWithFile([FromForm] UserAcademicModel input)
        {

            var result = await _UserAcademicService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedUserAcademic")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserAcademic(PagedResponseModel model)
        {
            var list = await _UserAcademicService.GetPagedUserAcademicResponse(model);
            return new JsonResult(list);
        }
        [Route("GetUserAcademicBYId")]
        [HttpGet]
        public async Task<IActionResult> GetUserAcademicBYId(int id)
        {
            var list = await _UserAcademicService.GetUserAcademicBYId(id);
            return new JsonResult(list);


        }


        [HttpPost]
        [Route("UserAcademicDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> UserAcademicDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserAcademicService.UserAcademicDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadAcademic")]
        public async Task<IActionResult> DownloadAcademic(long id)
        {

            var result = await _UserAcademicService.DownloadFile(id);
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
        /// UserProfessional


        [Route("UserProsessionalCreateWithFile")]
        [HttpPost]
        public async Task<IActionResult> UserProsessionalCreateWithFile([FromForm] UserProfessionalModel input)
        {

            var result = await _UserProfessionalService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }
        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadProfessional")]
        public async Task<IActionResult> DownloadProfessional(long id)
        {

            var result = await _UserProfessionalService.DownloadFile(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.DocumentsFilePath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.DocumentsContentType;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }

        [Route("GetPagedUserProfessional")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserProfessional(PagedResponseModel model)
        {
            var list = await _UserProfessionalService.GetPagedUserProfessionalResponse(model);
            return new JsonResult(list);
        }
        [Route("GetUserProfessionalBYId")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfessionalBYId(int id)
        {
            var list = await _UserProfessionalService.GetUserProfessionalBYId(id);
            return new JsonResult(list);


        }


        [HttpPost]
        [Route("UserProfessionalDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> UserProfessionalDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserProfessionalService.UserProfessionalDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

    
    /// UserEmployment


    [Route("UserEmploymentCreate")]
    [HttpPost]
    public async Task<IActionResult> UserEmploymentCreate(UserEmploymentModel input)
    {

        var result = await _UserEmploymentService.Create(input);
        return Ok(new Response { Status = result, Message = result });



    }

    [Route("GetPagedUserEmployment")]
    [HttpPost]
    public async Task<IActionResult> GetPagedUserEmployment(PagedResponseModel model)
    {
        var list = await _UserEmploymentService.GetPagedUserEmploymentResponse(model);
        return new JsonResult(list);
    }
    [Route("GetUserEmploymentBYId")]
    [HttpGet]
    public async Task<IActionResult> GetUserEmploymentBYId(int id)
    {
        var list = await _UserEmploymentService.GetUserEmploymentBYId(id);
        return new JsonResult(list);


    }


    [HttpPost]
    [Route("UserEmploymentDeleteById")]
    //  [Authorize]
    public async Task<IActionResult> UserEmploymentDeleteById(long id)
    {
        // SecUserService secuserservice = new SecUserService();
        var result = await _UserEmploymentService.UserEmploymentDeleteById(id);
        return Ok(new Response { Status = result, Message = result });

    }
        /// UserCPD


        [Route("UserCPDCreate")]
        [HttpPost]
        public async Task<IActionResult> UserCPDCreate([FromForm] UserCPDModel input)
        {

            var result = await _UserCPDService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedUserCPD")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserCPD(PagedResponseModel model)
        {
            var list = await _UserCPDService.GetPagedUserCPDResponse(model);
            return new JsonResult(list);
        }
        [Route("GetUserCPDBYId")]
        [HttpGet]
        public async Task<IActionResult> GetUserCPDBYId(int id)
        {
            var list = await _UserEmploymentService.GetUserEmploymentBYId(id);
            return new JsonResult(list);


        }


        [HttpPost]
        [Route("UserCPDDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> UserCPDDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserCPDService.UserCPDDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadCPD")]
        public async Task<IActionResult> DownloadCPD(long id)
        {

            var result = await _UserCPDService.DownloadFile(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.DocumentsFilePath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.DocumentsContentType;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }

        /// UserConsultancy


        [Route("UserConsultancyCreate")]
        [HttpPost]
        public async Task<IActionResult> UserConsultancyCreate(UserConsultancyModel input)
        {

            var result = await _UserConsultancyService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedUserConsultancy")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserConsultancy(PagedResponseModel model)
        {
            var list = await _UserConsultancyService.GetPagedUserConsultancyResponse(model);
            return new JsonResult(list);
        }
        [Route("GetUserConsultancyBYId")]
        [HttpGet]
        public async Task<IActionResult> GetUserConsultancyBYId(int id)
        {
            var list = await _UserConsultancyService.GetUserConsultancyBYId(id);
            return new JsonResult(list);


        }


        [HttpPost]
        [Route("UserConsultancyDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> UserConsultancyDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserConsultancyService.UserConsultancyDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
        [Route("GetPagedUserRemarks")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserRemarks(PagedResponseModel model)
        {
            var list = await _secUserService.GetPagedUserRemarks(model);
            return new JsonResult(list);
        }



        /// UserAudit


        [Route("UserAuditCreate")]
        [HttpPost]
        public async Task<IActionResult> UserAuditCreate(UserAuditModel input)
        {

            var result = await _UserAuditService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedUserAudit")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserAudit(PagedResponseModel model)
        {
            var list = await _UserAuditService.GetPagedUserAuditResponse(model);
            return new JsonResult(list);
        }
        [Route("GetUserAuditBYId")]
        [HttpGet]
        public async Task<IActionResult> GetUserAuditBYId(int id)
        {
            var list = await _UserAuditService.GetUserAuditBYId(id);
            return new JsonResult(list);


        }


        [HttpPost]
        [Route("UserAuditDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> UserAuditDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserAuditService.UserAuditDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

        /// UserAuditNace


        [Route("UserAuditorNaceCreate")]
        [HttpPost]
        public async Task<IActionResult> UserAuditorNaceCreate(UserAuditorNaceModel input)
        {

            var result = await _UserAuditorNaceService.Create(input);
            return Ok(new Response { Status = result, Message = result });



        }

        [Route("GetPagedUserAuditorNace")]
        [HttpPost]
        public async Task<IActionResult> GetPagedUserAuditorNace(PagedResponseModel model)
        {
            var list = await _UserAuditorNaceService.GetPagedUserAuditorNaceResponse(model);
            return new JsonResult(list);
        }
        [Route("GetUserAuditorNaceBYId")]
        [HttpGet]
        public async Task<IActionResult> GetUserAuditorNaceBYId(int id)
        {
            var list = await _UserAuditorNaceService.GetUserAuditorNaceBYId(id);
            return new JsonResult(list);


        }


        [HttpPost]
        [Route("UserAuditorNaceDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> UserAuditorNaceDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserAuditorNaceService.UserAuditorNaceDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadConfidentially")]
        public async Task<IActionResult> DownloadConfidentially(long id)
        {

            var result = await _secUserService.DownloadConfidentiallyFile(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.ConfidentialityPath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.ConfidentialityContentType;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }
        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadContractFile")]
        public async Task<IActionResult> DownloadContractFile(long id)
        {

            var result = await _secUserService.DownloadContractFile(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.ContractPath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.ContractContentType;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadImage")]
        public async Task<IActionResult> DownloadImage(long id)
        {

            var result = await _secUserService.DownloadImage(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.PhotoPath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.PhotoContentType;
            var fileNM = Path.GetFileName(fileName);
            //   var net = new System.Net.WebClient();
            //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
            // var data = net.DownloadData(fname);
            // var content = new System.IO.MemoryStream(data);
            //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }

        [Route("UCreate")]
        [HttpPost]
        public async Task<IActionResult> UCreate(ResetPasswordModel input)
        {

            var result = await _secUserService.UCreate(input);
            return Ok(new Response { Status = result, Message = result });



        }
        [HttpGet, DisableRequestSizeLimit]
        [Route("DownloadStandards")]
        public async Task<IActionResult> DownloadStandards(long id)
        {

            var result = await _UserStandardService.DownloadFile(id);
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

        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(long id)
        {
            var List = await _AllDropdownService.GetAllUsers(id);
            return new JsonResult(List);
        }

        [HttpPost]
        [Route("StandardApproval")]
        public async Task<IActionResult> StandardApproval(UserStandardModel input)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserStandardService.StandardApproval(input);
            return Ok(new Response { Status = result, Message = result });

        }
        [HttpPost]
        [Route("AuditorNaceApproval")]
        public async Task<IActionResult> AuditorNaceApproval(UserAuditorNaceModel input)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _UserAuditorNaceService.AuditorNaceApproval(input);
            return Ok(new Response { Status = result, Message = result });

        }
        //[Authorize]
        // [Route("GetBuldings")]
        // [HttpGet]
        // public async Task<IActionResult> GetBuldings()
        // {
        //     var List = await _AllDropdownService.GetAllBuildings();
        //     return new JsonResult(List);
        // }


        // [Route("GetFlats")]
        // [HttpGet]
        // public async Task<IActionResult> GetFlats(long id)
        // {
        //     var List = await _AllDropdownService.GetAllFlatesByFloor(id);
        //     return new JsonResult(List);
        // }

        // [Route("GetFloors")]
        // [HttpGet]
        // public async Task<IActionResult> GetFloors(long id)
        // {
        //     var List = await _AllDropdownService.GetAllFloorsbyBuilding(id);
        //     return new JsonResult(List);
        // }

        // [Route("GetAllPriorities")]
        // [HttpGet]
        // public async Task<IActionResult> GetPriorities()
        // {
        //     var List = await _AllDropdownService.GetAllPriorities();
        //     return new JsonResult(List);
        // }
    }
}
