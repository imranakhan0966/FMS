using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces
{
  public  interface IUserCPDService
    {
        Task<string> Create(UserCPDModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserCPDModel> GetPagedUserCPDResponse(PagedResponseModel model);
        Task<UserCPDModel> GetUserCPDBYId(long id);


        Task<string> UserCPDDeleteById(long id);
        Task<UserCPDModel> DownloadFile(long id);
       

        //Task<List<CertificationModel>> GetAllCertification();
    }
}
