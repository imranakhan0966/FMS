using Ozone.Application.DTOs;
//using Ozone.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
  public  interface IProjectIsoService
    {
        Task<string> Create(ProjectIsoModel input);
        Task<string> ContractSubmit(ClientProjectModel input);
        Task<string> ContractApproval(ClientProjectModel input);

        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        // Task<GetPagedProjectSlcpModel> GetPagedProjectSlcp(PagedResponseModel model);
        // Task<ProjectSA8000CreateModel> GetProjectSA8000BYId(long id);
        Task<string> ProjectIsoDeleteById(long id);
        Task<ProjectIsoModel> DownloadFile(long id);
        Task<GetPagedProjectISOModelForView> GetProjectIsoBYId(long id);

        Task<string> Approval(ProjectRemarksHistoryModel input);

        Task<string> SubmitForReview(long id, long loginUserId);
        Task<ClientProjectModel> downloadContract(long id);
    }
}
