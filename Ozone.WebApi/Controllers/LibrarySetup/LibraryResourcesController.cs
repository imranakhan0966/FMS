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

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryResourcesController : BaseApiController
    {
        // private UserService _userService;
        private readonly IConfiguration _configuration;


        ISecUserSessionService _userSessionService;
        ILibraryResources _LibraryResourceService;
        private readonly IJwtAuthManager _jwtAuthManager;

        //public AuthenticateController(UserManager<SecUser> userManager, IConfiguration configuration)
        public LibraryResourcesController(
            // UserService userService,
            IConfiguration configuration,

            ISecUserSessionService userSessionService,
            ILibraryResources libraryResourceService,
            IJwtAuthManager jwtAuthManager
            )
        {
            //this.userManager = userManager;
            // this._userService = userService;
            _configuration = configuration;
            // this._authService = authService;
            this._userSessionService = userSessionService;
            this._LibraryResourceService = libraryResourceService;
            this._jwtAuthManager = jwtAuthManager;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}


        // public async


        [Route("GetModule")]
        [HttpGet]
        public async Task<IActionResult> GetModule()
        {
            //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            //IPAddress ipAddress = ipHostInfo.AddressList[0];

            //var add = ipAddress.ToString();
            //string oldPath = @"D:\Create Entity by Data base First approch.txt";
            //string newpath = @"D:\COI\";

            //string newFileName = "new file name";
            //FileInfo f1 = new FileInfo(oldPath);
            //var name =f1.FullName;
            //if (f1.Exists)
            //{
            //    if (!Directory.Exists(newpath))
            //    {
            //        Directory.CreateDirectory(newpath);
            //    }
            //    f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, f1.Extension));
            //}
            var List = await _LibraryResourceService.GetAllModule();
            return new JsonResult(List);
        }

        [Route("GetStandard")]
        [HttpGet]
        public async Task<IActionResult> GetStandard()
        {
            //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            //IPAddress ipAddress = ipHostInfo.AddressList[0];

            //var add = ipAddress.ToString();
            //string oldPath = @"D:\Create Entity by Data base First approch.txt";
            //string newpath = @"D:\COI\";

            //string newFileName = "new file name";
            //FileInfo f1 = new FileInfo(oldPath);
            //var name =f1.FullName;
            //if (f1.Exists)
            //{
            //    if (!Directory.Exists(newpath))
            //    {
            //        Directory.CreateDirectory(newpath);
            //    }
            //    f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, f1.Extension));
            //}
            var List = await _LibraryResourceService.GetAllStandard();
            return new JsonResult(List);
        }
        [Route("getdata")]
        [HttpPost]
        public async Task<IActionResult> getdata(Dictionary<string, string> keyValuePairs, int model)
        {

            var List = await _LibraryResourceService.GetAlldata(keyValuePairs, model);
            return new JsonResult(List);
        }
        [Route("GetDocumentsType")]
        [HttpGet]
        public async Task<IActionResult> GetDocumentsType()
        {
            var List = await _LibraryResourceService.GetDocumentsType();
            return new JsonResult(List);
        }
        [Route("GetAllReviewer")]
        [HttpGet]
        public async Task<IActionResult> GetAllReviewer(long id)
        {
            var List = await _LibraryResourceService.GetAllReviewer(id);
            return new JsonResult(List);
        }
        [Route("GetAllStatus")]
        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            var List = await _LibraryResourceService.GetAllStatus();
            return new JsonResult(List);
        }
        [Route("GetAllCertification")]
        [HttpGet]
        public async Task<IActionResult> GetAllCertification()
        {
            var List = await _LibraryResourceService.GetAllCertification();
            return new JsonResult(List);
        }
        //[Route("CreateLibrary")]
        //[HttpPost]
        //public async Task<IActionResult> CreateLibrary(LibraryResourcesModel input)
        //{
        //    // SecUserService secuserservice = new SecUserService();
        //    var result = await _LibraryResourceService.CreateLibrary(input);
        //    return Ok(new Response { Status = result, Message = result });

        //}
       
        [Route("CreateLibrary")]
        [HttpPost]
        public async Task<IActionResult> CreateLibrary([FromForm] LibraryResourcesModel input)
        {
          //  string filename = Path.GetFileName(input.File.FileName);
          //string ContentType = Path.GetFileName(input.File.ContentType);
          //  // input.File.SaveAs(Server.MapPath("Files/" + filename));

          //  //string oldPath = @"D:\";
          ////  string newpath = @"D:\COI\" + filename;
          //  string newFileName = @"D:\Update work\"+ filename;
          //  fname = newFileName;
          //  //FileInfo f1 = new FileInfo(oldPath);
          //  //if (f1.Exists)
          //  //{
          //  //    if (!Directory.Exists(newpath))
          //  //    {
          //  //        Directory.CreateDirectory(newpath);
          //  //    }
          //  //    f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, f1.Extension));
          //  //}


          //  using (var stream = new FileStream(newFileName, FileMode.Create))
          //  {
          //      await input.File.CopyToAsync(stream);

          //  }
            // SecUserService secuserservice = new SecUserService();
            var result = await _LibraryResourceService.CreateLibrary(input);
            return Ok(new Response { Status = result, Message = result });

            //var net = new System.Net.WebClient();
            //var data = net.DownloadData(newFileName);
            //var content = new System.IO.MemoryStream(data);
            //var contentType = ContentType;
            //CType = contentType;
            //var fileName = newFileName;
            //return File(content, contentType, fileName);



            //string path = e.CommandArgument.ToString();
            //string name = Path.GetFileName(path);
            //string ext = Path.GetExtension(path);
            //Response.AppendHeader("content-disposition", "attachment; filename=" + name);
            //Response.ContentType = "application/octet-stream";
            //Response.WriteFile(path);
            //Response.End();
            // return Ok(new Response { Status = result, Message = result });

        }

        //[HttpGet]
        [HttpPost]
        [Route("CreateLibraryData")]
       
        public async Task<IActionResult> CreateLibraryData([FromForm] LibraryModelForCreate input)
        {
            //  string filename = Path.GetFileName(input.File.FileName);
            //string ContentType = Path.GetFileName(input.File.ContentType);
            //  // input.File.SaveAs(Server.MapPath("Files/" + filename));

            //  //string oldPath = @"D:\";
            ////  string newpath = @"D:\COI\" + filename;
            //  string newFileName = @"D:\Update work\"+ filename;
            //  fname = newFileName;
            //  //FileInfo f1 = new FileInfo(oldPath);
            //  //if (f1.Exists)
            //  //{
            //  //    if (!Directory.Exists(newpath))
            //  //    {
            //  //        Directory.CreateDirectory(newpath);
            //  //    }
            //  //    f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, f1.Extension));
            //  //}


            //  using (var stream = new FileStream(newFileName, FileMode.Create))
            //  {
            //      await input.File.CopyToAsync(stream);

            //  }
            // SecUserService secuserservice = new SecUserService();
            var result = await _LibraryResourceService.CreateLibraryNew(input);
            return Ok(new Response { Status = result, Message = result });

            //var net = new System.Net.WebClient();
            //var data = net.DownloadData(newFileName);
            //var content = new System.IO.MemoryStream(data);
            //var contentType = ContentType;
            //CType = contentType;
            //var fileName = newFileName;
            //return File(content, contentType, fileName);



            //string path = e.CommandArgument.ToString();
            //string name = Path.GetFileName(path);
            //string ext = Path.GetExtension(path);
            //Response.AppendHeader("content-disposition", "attachment; filename=" + name);
            //Response.ContentType = "application/octet-stream";
            //Response.WriteFile(path);
            //Response.End();
            // return Ok(new Response { Status = result, Message = result });

        }




        [HttpGet, DisableRequestSizeLimit]
        [Route("download")]
        public async Task<IActionResult> Download(long id)
        {

            var result = await _LibraryResourceService.DownloadLibrary(id);
            //  var fileName = @"G:/OzoneDocuments/LibraryDocument/10_AD Requirement.txt";
            var fileName = result.FilePath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // var contenpe = "application/pdf";
            var contenpe = result.ContentType;
            var fileNM = Path.GetFileName(fileName);
         //   var net = new System.Net.WebClient();
          //  var data = net.DownloadData(@"D:/Update work/OT Booking.pdf");
           // var data = net.DownloadData(fname);
           // var content = new System.IO.MemoryStream(data);
          //  var contentType = "application/pdf";
            //var fileName = "OT Booking.pdf";
            return File(memory, contenpe, fileNM);
        }
        //[Route("CreateLibrary")]
        //[HttpPost]
        //public async Task<IActionResult> CreateLibrary(LibraryResourcesModel input)
        //{

        //    //string oldPath = @"D:\";
        //    //string newpath = @"D:\COI\";
        //    //string newFileName = "new file name";
        //    //FileInfo f1 = new FileInfo(oldPath);
        //    //if (f1.Exists)
        //    //{
        //    //    if (!Directory.Exists(newpath))
        //    //    {
        //    //        Directory.CreateDirectory(newpath);
        //    //    }
        //    //    f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, f1.Extension));
        //    //}
        //    // SecUserService secuserservice = new SecUserService();
        //    var result = await _LibraryResourceService.CreateLibrary(input);
        //    return Ok(new Response { Status = result, Message = result });

        //}
        [Route("GetPagedLibrary")]
        [HttpPost]
        public async Task<IActionResult> GetPagedLibrary(PagedResponseModel model)
        {
            var list = await _LibraryResourceService.GetPagedLibraryResourcesResponse(model);
            return new JsonResult(list);
        }
        [Route("GetLibraryDataById")]
        [HttpGet]
        public async Task<IActionResult> GetLibraryDataById(int id)
        {
            var list = await _LibraryResourceService.GetLibraryBYId(id);
            return new JsonResult(list);


        }
        [HttpPost]
        [Route("LibraryDeleteById")]
        //  [Authorize]
        public async Task<IActionResult> LibraryDeleteById(long id)
        {
            // SecUserService secuserservice = new SecUserService();
            var result = await _LibraryResourceService.LibraryDeleteById(id);
            return Ok(new Response { Status = result, Message = result });

        }
        
        [Route("GetDocumentsByStandardId")]
        [HttpPost]
        public async Task<IActionResult> GetDocumentsByStandardId(long Id,PagedResponseModel model)
        {
            var list = await _LibraryResourceService.GetDocumentsByStandardId(Id,model);
            return new JsonResult(list);
        }
    }
}
