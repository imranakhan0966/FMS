using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Ozone.Application.Interfaces
{
   public interface IUserStandardService
    {
        Task<string> SubmitForReviewStatus(long id);
      

        Task<string> Create(UserStandardModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserStandardModel> GetPagedUserStandardResponse(PagedResponseModel model);
        Task<UserStandardModel> GetUserStandardBYId(long id);
       

        Task<string> UserStandardDeleteById(long id);
        Task<List<AuditorTypeModel>> GetAllAuditorType(long? OrganizationId);
        Task<List<CourseTypeModel>> GetAllCourseType();
        Task<List<ApprovalStatusModel>> GetAllApprovalStatus();
        Task<List<CertificationModel>> GetAllCertification();
        Task<List<CertificationBodyModel>> GetAllCertificationBody();
        Task<List<AuditTypeModel>> GetAllAuditType();
        Task<UserStandardModel> DownloadFile(long id);
        Task<string> StandardApproval(UserStandardModel input);




    }
}
