using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedProjectSA8000Model
    {
        public int TotalCount { get; set; }
        public List<ProjectSA8000Model> ProjectSA8000Model { get; set; }
    }
    public class GetPagedClientProjectModel
    {
        public ClientProjectModel ClientProjectModel { get; set; }
        public ProjectSA8000Model ProjectSA8000Model { get; set; }
        public ClientSitesModel ClientSitesModel { get; set; }
    }

    public class GetPagedProjectHiggModel
    {
        public int TotalCount { get; set; }
        public List<ProjectHiggModel> ProjectHiggModel { get; set; }
    }
    public class GetPagedProjectHiggModelForView
    {
        public ClientProjectModel ClientProjectModel { get; set; }
        public ProjectHiggModel ProjectHiggModel { get; set; }
        public ClientSitesModel ClientSitesModel { get; set; }
    }

    public class GetPagedProjectSLCPModelForView
    {
        public ClientProjectModel ClientProjectModel { get; set; }
        public ProjectSLCPModel ProjectSLCPModel { get; set; }
        public ClientSitesModel ClientSitesModel { get; set; }
    }
    public class GetPagedProjectISOModelForView
    {
        public ClientProjectModel ClientProjectModel { get; set; }
        public ProjectIsoModel ProjectIsoModel { get; set; }
        public ClientSitesModel ClientSitesModel { get; set; }
    }
}
