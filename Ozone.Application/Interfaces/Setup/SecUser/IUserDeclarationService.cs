using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Ozone.Application.Interfaces
{
   public interface IUserDeclarationService
    {
        Task<string> Create(UserDeclarationModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserDeclarationModel> GetPagedUserDeclarationResponse(PagedResponseModel model);
        Task<UserDeclarationModel> GetUserDeclarationBYId(long id);


        Task<string> UserDeclarationDeleteById(long id);
        //Task<List<ApprovalStatusModel>> GetAllApprovalStatus();
        Task<List<ContractTypeModel>> GetAllContractType();
    }
}
