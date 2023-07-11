using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Ozone.Application.Interfaces
{
  public  interface IUserAuditService
    {
        Task<string> Create(UserAuditModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserAuditModel> GetPagedUserAuditResponse(PagedResponseModel model);
        Task<UserAuditModel> GetUserAuditBYId(long id);


        Task<string> UserAuditDeleteById(long id);
        Task<List<CertificationBodyModel>> GetAllCertificationBody();
        //Task<List<NaceCodeModel>> GetAllNaceCode();
        //Task<List<AuditorTypeModel>> GetAllAudit();
        //Task<List<CertificationModel>> GetAllCertification();
    }
}
