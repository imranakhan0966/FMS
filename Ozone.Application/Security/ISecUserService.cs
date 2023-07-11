using Ozone.Application.DTOs;
using Ozone.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Security
{
    public interface ISecUserService
    {
        Task<string> SubmitForReview(long id);
        Task<SecUserPagedModel> GetPagedSecUserReponse(long id,PagedResponseModel model);
        Task<SecUserModel> GetAllLocationsByUserId(long id);
        Task<string> CreateUser(SecUserModel input);


        Task<string> UCreate(ResetPasswordModel input);
        Task<string> Approval(SecUserModel input);
        
         Task<string> Update(SecUserModel input);
        Task<SecUserModel> GetById(int id);
        Task<string> CreateUserPassword(SecUserPasswordModel input);
        Task AuthorizeUser(long id, string Remarks);
        Task RejectUser(long id, string Remarks);
        Task<string> CreateUserWithFiles(UserDataWithFilesModel input);
        Task<SecUserModel> GetUserDataById(long id);
        Task<string> UserDeleteById(long id);
        Task<GetPagedUserRemarksModel> GetPagedUserRemarks(PagedResponseModel model);

        Task<SecUserModel> DownloadConfidentiallyFile(long id);
        Task<SecUserModel> DownloadContractFile(long id);
        Task<SecUserModel> DownloadImage(long id);
        // Task<string> DeleteUser(long id);
    }
}
