using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedClientModel
    {
        public int TotalCount { get; set; }
        public List<ClientModel> ClientModel { get; set; }
    }
    public class GetPagedClientSitesModel
    {
        public int TotalCount { get; set; }
        public List<ClientSitesModel> ClientSitesModel { get; set; }
    }
    public class GetPagedClientProjectsModel
    {
        public int TotalCount { get; set; }
        public List<ClientProjectModel> ClientProjectModel { get; set; }
        public List<ClientAuditVisitModel> ClientAuditVisitModel { get; set; }
    }
}
