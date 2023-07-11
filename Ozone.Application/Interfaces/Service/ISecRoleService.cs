using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Security;
using Ozone.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ozone.Application.Interfaces.Service
{
    public interface ISecRoleService
    {
        Task<SecRolePagedModel> GetPagedSecRoleReponse(PagedResponseModel model);
        Task<string> CreateSecRoleService(SecRoleFormPagedModel model);
        Task<string> CreateSecRoleForm(SecRoleModelUpdate model);
        Task<string> Update(SecRoleModelUpdate model);
        Task<List<SecRoleFormPagedModel>> GetPagedRoleFormReponseService(QueryParameter parameter);
        Task<List<SecRoleFormPagedModel>> GetAllRoles(long id);
        Task<List<SecUserTypeModel>> GetAllUserType(long id);
        Task<List<SecRoleFormLoginModel>> GetAllRoleFormByRoleId(long id);
        Task<List<SecFormPagedModel>> GetPagedSecFormReponseService(QueryParameter parameter);
        Task<List<SecRoleFormModel>> GetSecRoleForm(QueryParameter parameter);
        Task<SecRoleModelUpdate> GetAllPermissionsByRoleId(long id);
        Task<List<SecRoleModelUpdate>> GetAllSecRoleForm();
        Task AuthorizeRole(long id, string Remarks);
        Task RejectRole(long id, string Remarks);
        Task<List<CityModel>> GetAllCities();
        Task<List<CountryModel>> GetAllCountry();
        Task<List<PrefixModel>> GetAllPrefix();
        Task<List<StateModel>> GetAllState();
        Task<List<IsActiveModel>> GetAllActiveStatus();

    }
}
