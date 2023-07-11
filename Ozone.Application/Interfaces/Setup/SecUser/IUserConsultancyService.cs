using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces
{
    public interface IUserConsultancyService
    {
        Task<string> Create(UserConsultancyModel input);
        // Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseStandardModel model);
        Task<GetPagedUserConsultancyModel> GetPagedUserConsultancyResponse(PagedResponseModel model);
        Task<UserConsultancyModel> GetUserConsultancyBYId(long id);


        Task<string> UserConsultancyDeleteById(long id);
        Task<List<EACodeModel>> GetAllEACode();
        Task<List<NaceCodeModel>> GetAllNaceCode();
       
        //Task<List<CertificationModel>> GetAllCertification();
    }
}
