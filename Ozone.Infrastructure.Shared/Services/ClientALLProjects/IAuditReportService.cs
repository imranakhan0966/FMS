using Ozone.Application.DTOs;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Ozone.Infrastructure.Shared.Services
{
   public interface IAuditReportService
    {
        //Task<string> Create(AuditVisitReportMasterModel input);
        Task<string> CreateAuditReport(AuditVisitReportMasterModel input);
        
        Task<GetPagedAuditReportModel> GetPagedAuditReportResponse(PagedResponseModel model);
        Task<GetPagedAuditReportModel> GetPagedAuditReportResponseById(long id,PagedResponseModel model);
        Task<AuditVisitReportMasterModel> AuditReportBYId(long id);
        Task<string> AuditReportDeleteById(long id);
        Task<AuditVisitReportMasterModel> DownloadAuditReport(long id);
        Task<GetPagedAuditVisitReportMasterModel> GetPagedAuditReportDetailById(long id, PagedResponseModel model);
        Task<GetPagedQCDocumentsListModel> QCDocumentsList(long id, PagedResponseModel model);
        Task<List<QCHistoryModel>>QcHistory(long AuditVisitId);
        Task<string> AddComment(QCHistoryModel input);
        Task<string> AddCommentList(List<QCHistoryModel> input);
        Task<string> QCCommentsDeleteById(long id);
        Task <List<QcStatus>> GetAllQcStatus();
        Task<string> SubmitForReview(long id, long loginUserId);




    }
}
