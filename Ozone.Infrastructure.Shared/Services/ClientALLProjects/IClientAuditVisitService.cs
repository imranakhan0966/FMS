using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Security;

using Ozone.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
   public interface IClientAuditVisitService
    {
        Task<string> Create(ClientAuditVisitModel input);
        Task<GetPagedClientAuditVisitModel> GetPagedClientAuditVisitResponse(long ProjectId, PagedResponseModel model);
        Task<ClientAuditVisitModel> GetClientAuditVisitBYId(long id);
        Task<string> ClientAuditVisitDeleteById(long id);
        Task<GetPagedClientAuditVisitModel> AuditPlan(long id,PagedResponseModel model);
        Task<ClientAuditVisitModel> DownloadAuditPlan(long id);

        //Task<string> AuditPlaneSubmitForReview(long id, long loginUserId);
       // Task<string> AuditComplete(long id);
        Task<string> AuditComplete(ClientAuditVisitModel input);
        Task<GetPagedProjectStatusModel> ProjectStatus(long id , PagedResponseModel model);
    }
}
