using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface IQcDocumentService
    {
        Task<string> Create(QCDocumentsListModel input);
        Task<GetPagedQcDocumentModel> GetPagedQcDocumentResponse(PagedResponseModel model);
        Task<QCDocumentsListModel> GetQcDocumentBYId(long id);
        Task<string> QcDocumentDeleteById(long id);
       
    }
}
