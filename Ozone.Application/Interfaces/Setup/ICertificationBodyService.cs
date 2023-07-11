using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface ICertificationBodyService
    {
        Task<string> Create(CertificationBodyModel input);
        Task<GetPagedCertificationBodyModel> GetPagedCertificationBodyResponse(PagedResponseModel model);
        Task<CertificationBodyModel> GetCertificationBodyBYId(long id);
        Task<string> CertificationBodyDeleteById(long id);

    }
}
