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
  
        public interface ILibraryResources
        {
            Task<GetPagedLibraryModel> GetPagedLibraryResourcesResponse(PagedResponseModel model);
            Task<List<ModuleModel>> GetAllModule();
            Task<List<DocumentsTypeModel>> GetDocumentsType();
            Task<List<SecUserModel>> GetAllReviewer(long orgId);
            Task<List<StatusModel>> GetAllStatus();
            Task<List<CertificationModel>> GetAllCertification();
            Task<string> CreateLibrary(LibraryResourcesModel input);
            Task<string> CreateLibraryNew(LibraryModelForCreate input);
            Task <LibraryResourcesModel> GetLibraryBYId(long id);
            Task<LibraryResourcesModel> DownloadLibrary(long id);
        Task<List<CertificationModel>> GetAllStandard();


        Task<GetPagedLibraryModel> GetAlldata(Dictionary<string, string> keyValuePairs, int model);
        Task<string> LibraryDeleteById(long id);

        Task<GetPagedLibraryModel> GetDocumentsByStandardId(long StandardId, PagedResponseModel model);


    }


}
