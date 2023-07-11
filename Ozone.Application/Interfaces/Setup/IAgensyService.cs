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
   public interface IAgensyService
    {

        Task<GetPagedAgencyModel> GetPagedAgency(PagedResponseModel model);
       
        Task<List<SecRoleFormPagedModel>> GetAllRoles(long id);
        Task<OrganizationModel> GetAgencyBYId(long id);
        Task<string> CreateAgency(OrganizationModel input);
        Task<string> AgencyDeleteById(long id);
    }
}
