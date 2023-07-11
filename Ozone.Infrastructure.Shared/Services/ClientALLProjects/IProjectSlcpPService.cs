using Ozone.Application.DTOs;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Ozone.Infrastructure.Shared.Services
{
    public interface IProjectSlcpPService
    {
        Task<string> Create(ProjectSLCPModel input);
        Task<string> ContractSubmit(ClientProjectModel input);
        Task<string> ContractApproval(ClientProjectModel input);

        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        // Task<GetPagedProjectSlcpModel> GetPagedProjectSlcp(PagedResponseModel model);
        // Task<ProjectSA8000CreateModel> GetProjectSA8000BYId(long id);
        Task<string> ProjectSlcpDeleteById(long id);
        Task<ProjectSLCPModel> DownloadFile(long id);
        Task<GetPagedProjectSLCPModelForView> GetProjectSlcpBYId(long id);

        Task<string> Approval(ProjectRemarksHistoryModel input);

        Task<string> SubmitForReview(long id, long loginUserId);
        Task<ClientProjectModel> downloadContract(long id);
    }
}
