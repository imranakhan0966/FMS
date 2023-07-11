using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Security;

using Ozone.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces
{
   public interface IClientService
    {

        Task<GetPagedClientModel> GetPagedClient(long orgid, PagedResponseModel model);

     
        Task<ClientModel> GetClientBYId(long id);
        Task<string> CreateClient(ClientModel input);
        Task<string> ClientDeleteById(long id);
        Task<List<UserStandardModel>> GetAuditorByStandardId(long id, long? OrganizationId);
        Task<List<UserStandardModel>> GetReviewerByStandardId(long id);
        Task<UserStandardModel> GetReviewerByStandard(long? standardId, long? userId);

        Task<List<UserStandardModel>> GetLeadAuditorByStandardId(long id, long? OrganizationId);
        //Task<ClientModel> GetClienfulltBYId(long id);
    }
}
