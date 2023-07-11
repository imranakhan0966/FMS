using Ozone.Application.DTOs;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
   public interface IProjectHiggService
    {
        Task<string> Create(ProjectHiggModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
       // Task<GetPagedProjectHiggModel> GetPagedProjectHigg(PagedResponseModel model);
        // Task<ProjectSA8000CreateModel> GetProjectSA8000BYId(long id);
        Task<string> ProjectHiggDeleteById(long id);
        Task<ProjectHiggModel> DownloadFile(long id);
        Task<GetPagedProjectHiggModelForView> GetProjectHiggBYId(long id);

        Task<string> Approval(ProjectRemarksHistoryModel input);

        Task<string> SubmitForReview(long id, long loginUserId);

        Task<string> ContractSubmit(ClientProjectModel input);
    }
}
