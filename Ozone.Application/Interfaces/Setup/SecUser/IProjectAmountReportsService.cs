using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Projects;
using Ozone.Application.DTOs.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces
{
    public interface IProjectAmountReportsService
    {
        //Task<GetPagedProjectAmountReportsModel> GetPagedProjectAmountReports(PagedResponseModel model);

        Task<GetPagedProjectLedgerModel> GetPagedProjectLedger(PagedResponseModel model);
        //Task<GetPagedProjectLedgerDetailModel> GetPagedProjectLedgerDetail(PagedResponseModel model);
        Task<List<OrganizationModel>> GetAllAgency();
        Task<string> Create(ProjectLedgerDetailModel input);
        Task<GetPagedProjectLedgerDetailModel> GetPagedProjectLedgerDetail(long id, PagedResponseModel model);
    }
}
