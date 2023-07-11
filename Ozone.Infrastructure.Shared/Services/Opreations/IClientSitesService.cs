using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
   public interface IClientSitesService
    {
        Task<string> CreateClientSites(ClientSitesModel input);

        Task<GetPagedClientSitesModel> GetPagedClientSites(PagedResponseModel model);
        Task<GetPagedClientProjectsModel> GetPagedClientProjects(long id,PagedResponseModel model);


        Task<ClientSitesModel> GetClientSitesBYId(long id);

        Task<GetPagedClientProjectsModel> GetPagedAllProjects(long id, PagedResponseModel model);
        Task<GetPagedClientProjectsModel> GetPagedAllAudits(long id, PagedResponseModel model);
        Task<string> ClientSitesDeleteById(long id);

        Task<ProjectFormPathModel> GetProjectUrlBYId(long id);




    }
}
