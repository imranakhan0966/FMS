using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
    public interface IProjectAmountService
    {
        Task<string> Create(ProjectAmountModel input);
        Task<GetPagedProjectAmountModel> GetPagedProjectAmountResponse(PagedResponseModel model);
        Task<ProjectAmountModel> GetProjectAmountBYId(long id);
        Task<string> ProjectAmountDeleteById(long id);
        Task<List<OrganizationModel>> GetAllAgency();
    }
}
