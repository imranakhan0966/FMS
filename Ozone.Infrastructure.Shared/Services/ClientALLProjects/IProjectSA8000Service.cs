using Ozone.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
  public  interface IProjectSA8000Service
    {
        Task<string> Create(ProjectSA8000CreateModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedProjectSA8000Model> GetPagedProjectSA8000(PagedResponseModel model);
       // Task<ProjectSA8000CreateModel> GetProjectSA8000BYId(long id);
        Task<string> ProjectSA8000DeleteById(long id);
        Task<ProjectSA8000Model> DownloadFile(long id);
        Task<GetPagedClientProjectModel> GetProjectSA8000BYId(long id);

        Task<string> Approval(ProjectRemarksHistoryModel input);

        Task<string> SubmitForReview(long id, long loginUserId);
        Task<string> ContractSubmit(ClientProjectModel input);
        Task<ClientProjectModel> downloadContract(long id);
        //Task<string> ContractApproval(ClientProjectModel input);
    }
}
