using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using AutoMapper;
using Ozone.Application;
using Ozone.Application.Interfaces;
using System.Linq;
using Microsoft.Extensions.Configuration;
namespace Ozone.Infrastructure.Shared.Services
{
    public class ProjectSlcpPService : GenericRepositoryAsync<ClientProjects>, IProjectSlcpPService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;

        public ProjectSlcpPService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        IUserSessionHelper userSession,
         IConfiguration configuration) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._userSession = userSession;
            //_mockData = mockData;
            this._configuration = configuration;
        }
        private static bool newproject = true;
        public async Task<string> Create(ProjectSLCPModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectRemarksHistory history = new ProjectRemarksHistory();
                ClientProjects Dbproject = null;
                ProjectSlcp DbResult = null;
                Dbproject = await Task.Run(() => _dbContext.ClientProjects.Where(x => x.Id == input.Id && x.IsDeleted == false).FirstOrDefault());
                if (Dbproject != null)
                {
                    DbResult = await Task.Run(() => _dbContext.ProjectSlcp.Where(x => x.ClientProjectId == Dbproject.Id && x.IsDeleted == false).FirstOrDefault());
                }

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if (Dbproject == null)
                    {
                        New = true;
                        Dbproject = new ClientProjects();
                        DbResult = new ProjectSlcp();
                        Dbproject.Date = DateTime.Now;

                        Dbproject.StandardId = input.StandardId.Value;
                        Dbproject.ApprovalStatusId = 6;
                        Dbproject.ClientId = input.ClientId;
                        Dbproject.ProjectCode = GetProgectCode(input.ClientSiteId.Value, Dbproject.StandardId);
                        if (newproject == true)
                        {
                            if (input.ProjectTypeId != null && input.ProjectTypeId > 0)
                            {
                                Dbproject.ProjectTypeId = input.ProjectTypeId;

                            }
                            else
                            {
                                Dbproject.ProjectTypeId = 3;
                            }
                        }
                        else
                        {
                            Dbproject.ProjectTypeId = 2;
                        }
                    }
                    ///// ClientProject
                    Dbproject.ClientSiteId = input.ClientSiteId.Value;
                    // Dbproject.StandardId = 7;
                    Dbproject.VerificationTypeId = input.VerificationTypeId;
                    // Dbproject.ProjectTypeId = 1;

                  
                    Dbproject.Remarks = input.Remarks;


                    // DbResult.Code = input.Code;
                   // DbResult.ProjectTypeId = input.ProjectTypeId;
                    DbResult.ServicesTypeId = input.ServicesTypeId;
                    DbResult.MethodologyId = input.MethodologyId;
                    DbResult.FromDate = input.FromDate;
                    DbResult.ToDate = input.ToDate;
                    DbResult.ApplicationDate = input.ApplicationDate;
                    DbResult.AssessmentCompletedId = input.AssessmentCompletedId;
                    DbResult.CompletedStepId = input.CompletedStepId;
                    DbResult.AccreditationId = input.AccreditationId;
                    DbResult.TentativeDate = input.TentativeDate;
                    DbResult.NoOfMd = input.NoOfMd;
                    DbResult.ModuleVersionId = input.ModuleVersionId;
                    DbResult.BodySelectDate = input.BodySelectDate;
                    DbResult.ModuleShareId = input.ModuleShareId;
                    DbResult.WindowPeriodDate = input.WindowPeriodDate;
                    DbResult.ModuleYear = input.ModuleYear;
                    DbResult.RequestOfSiteId = input.RequestOfSiteId;

                    DbResult.Remarks = input.Remarks;





                    if (New == true)
                    {
                        DbResult.CreatedById = input.CreatedById;
                        DbResult.CreatedDate = DateTime.Now;

                        Dbproject.CreatedById = input.CreatedById;
                        Dbproject.CreatedDate = DateTime.Now;
                        DbResult.IsDeleted = false;

                        Dbproject.IsActive = true;
                        Dbproject.IsDeleted = false;
                        Dbproject.ProjectSlcp.Add(DbResult);
                        await base.AddAsync(Dbproject);
                        //message = "Successfully Inserted!";
                        message = "1";
                    }
                    else
                    {
                        DbResult.LastModifiedById = input.LastModifiedById;
                        DbResult.LastModifiedDate = DateTime.Now;
                        Dbproject.LastModifiedById = input.LastModifiedById;
                        Dbproject.LastModifiedDate = DateTime.Now;
                        if (Dbproject.ProjectTypeId == 2 && input.ProjectTypeId == 0)
                        {
                            Dbproject.ProjectTypeId = 2;
                        }
                        else if (Dbproject.ProjectTypeId == 2 && input.ProjectTypeId == 1)
                        {
                            Dbproject.ProjectTypeId = 2;
                        }
                        else if (input.ProjectTypeId == 0)
                        {
                            Dbproject.ProjectTypeId = 3;
                        }
                        else if (input.ProjectTypeId == 1)
                        {
                            Dbproject.ProjectTypeId = 1;
                        }
                        //if (Dbproject.ApprovalStatusId != null)
                        //{
                        //   // Dbproject.ApprovalStatusId = 2;
                        //   // DbResult.ApprovalStatusId = 2;
                        //    //_dbContext.Entry(DbResult).State = (EntityState)System.Data.Entity.EntityState.Modified;

                        //    history.Remarks = input.Remarks;
                        //    history.RemarksById = input.LastModifiedById;
                        //    history.RemarksDate = DateTime.Now;
                        //    history.ProjectId = Dbproject.Id;
                        //    //history.RemarksById =input.LastModifiedById;

                        //    history.IsDeleted = false;
                        //    history.ApprovalStatusId = 2;
                        //    Dbproject.ProjectRemarksHistory.Add(history);
                        //}
                        await base.UpdateAsync(Dbproject);
                        // Dbproject.ProjectSa8000.(DbResult);

                        //message = "Successfully Updated!";
                        message = "2";
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();
                    newid = DbResult.Id;
                    if (input.ApplicationForm != null)
                    {
                        string filename = Path.GetFileName(input.ApplicationForm.FileName);
                        string ContentType = input.ApplicationForm.ContentType;

                        string reportPath = _configuration["Reporting:ProjectsSLCPPath"];

                        // string newFileName = @"D:\Update work\LIbrary_Documents\" + +newid + "_" + filename;

                        string newFileName = reportPath + +newid + "_" + filename;
                        // string newFileName = @"G:\OzoneDocuments\LibraryDocument\" + +newid + "_" + filename;
                        using (var stream = new FileStream(newFileName, FileMode.Create))
                        {
                            await input.ApplicationForm.CopyToAsync(stream);

                        }
                        DbResult.ApplicationFormPath = newFileName;
                        DbResult.ApplicationContentType = ContentType;
                        _dbContext.Update(DbResult);
                        var result2 = await _unitOfWork.SaveChangesAsync();

                    }


                    transaction.Commit();
                    return message;

                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "0";
                }



            }

        }

        public string GetProgectCode(long clientSiteId, long standardId)
        {

            //int? cmpid = 0;
            string Codelast = string.Empty;
            int newNO = 0;
            string ItemCode = string.Empty;
            string re = "-";
            //string code = "CAT-";

            var AgencyCode = "";
            var ClientCode = "";
            var clientSiteCode = "";
            var StandardCode = "";
            DateTime Date = System.DateTime.Now;
            string date = Date.ToString("yy");

            var ClientProjectMod = new ClientProjectModel();
            var ClientSitesModel = new ClientSitesModel();
            var ClientProject = _dbContext.ClientProjects.Include(x => x.ClientSite).Include(x => x.Standard).Include(x => x.Client).Include(x => x.Client.Organization).Where(x => x.StandardId == standardId && x.ClientSiteId == clientSiteId).OrderByDescending(a => a.Id).FirstOrDefault();
            ClientProjectMod = _mapper.Map<ClientProjectModel>(ClientProject);

            if (ClientProjectMod != null)

            {
                newproject = false;
                clientSiteCode = ClientProjectMod.ClientSiteCode.Substring(0, 3);
                AgencyCode = ClientProjectMod.AgencyCode.Substring(0, 3);
                ClientCode = ClientProjectMod.ClientCode.Substring(4, 3);
                StandardCode = ClientProjectMod.StandardCode;
                newNO = Convert.ToInt32(ClientProjectMod.ProjectCode.Substring(19, 3));
                // newNO++;

                newNO = newNO + 1;

                var newcode = newNO.ToString().PadLeft(3, '0');
                ItemCode = AgencyCode + re + ClientCode + re + StandardCode + re + clientSiteCode + re + date + re + newcode;
            }
            else
            {
                newproject = true;
                var ClientSite = _dbContext.ClientSites.Include(x => x.Client).Include(x => x.Client.Organization).Where(x => x.Id == clientSiteId && x.IsDeleted == false).OrderByDescending(a => a.Id).FirstOrDefault();
                ClientSitesModel = _mapper.Map<ClientSitesModel>(ClientSite);
                clientSiteCode = ClientSitesModel.Code.Substring(0, 3);
                AgencyCode = ClientSitesModel.AgencyCode.Substring(0, 3);
                ClientCode = ClientSitesModel.ClientCode.Substring(4, 3);

                StandardCode = _dbContext.Certification.Where(x => x.Id == standardId && x.IsDeleted == false).OrderByDescending(a => a.Id).Select(x => x.Code).FirstOrDefault();

                ItemCode = AgencyCode + re + ClientCode + re + StandardCode + re + clientSiteCode + re + date + re + "001";
            }


            return ItemCode;


        }

        public async Task<GetPagedProjectSLCPModelForView> GetProjectSlcpBYId(long id)
        {

            var result = new GetPagedProjectSLCPModelForView();
            var ProjectSLCPModel = new ProjectSLCPModel();
            var ClientProjectMod = new ClientProjectModel();
            var ClientSitesModel = new ClientSitesModel();
            var Dbresult = await Task.Run(() => _dbContext.ProjectSlcp.Where(x => x.ClientProjectId == id).FirstOrDefault());
            ProjectSLCPModel = _mapper.Map<ProjectSLCPModel>(Dbresult);
            var Dbresult2 = await Task.Run(() => _dbContext.ClientProjects.Include(x => x.ClientSite).Include(x => x.ClientSite.Client).Include(x=>x.ApprovalStatus).Where(x => x.Id == id).FirstOrDefault());
            ClientProjectMod = _mapper.Map<ClientProjectModel>(Dbresult2);
            var Dbresult3 = await Task.Run(() => _dbContext.ClientSites.Where(x => x.Id == Dbresult2.ClientSiteId).FirstOrDefault());
            ClientSitesModel = _mapper.Map<ClientSitesModel>(Dbresult3);
            //var Dbresult3 = await Task.Run(() => _dbContext.ClientSites.Where(x => x.Id == Dbresult2.ClientSiteId).FirstOrDefault());
            //ClientSitesModel = _mapper.Map<ClientSitesModel>(Dbresult3);


            result.ProjectSLCPModel = ProjectSLCPModel;
            result.ClientProjectModel = ClientProjectMod;
            result.ClientSitesModel = ClientSitesModel;

            return result;
        }

        //private List<ProjectSLCPModel> GetPage(List<ProjectSLCPModel> list, int page, int pageSize)
        //{
        //    return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //}
        //public async Task<GetPagedProjectSLCPModel> GetPagedProjectSlcp(PagedResponseModel model)
        //{
        //    try
        //    {

        //        var result = new GetPagedProjectSLCPModel();
        //        var UserStdList = new List<ProjectSA8000Model>();

        //        //if (model.AuthAllowed == true)
        //        //{
        //        //var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true &&
        //        //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
        //        //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();

        //        var list = await _dbContext.ProjectSa8000.Where(x => x.IsDeleted == false).ToListAsync();
        //        UserStdList = _mapper.Map<List<ProjectSA8000Model>>(list);
        //        // return list;
        //        //}


        //        //else
        //        //{
        //        //    var list = await _dbContext.Certification.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
        //        //                 (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
        //        //                x.Code.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
        //        //    productDenoList = _mapper.Map<List<StandardModel>>(list);
        //        //    // return list;
        //        //}
        //        //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

        //        result.ProjectSA8000Model = GetPage(UserStdList, model.Page, model.PageSize);
        //        result.TotalCount = UserStdList.Count();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public async Task<string> ProjectSlcpDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {

                ClientProjects Project = _dbContext.ClientProjects.Where(u => u.Id == id).FirstOrDefault();
                ProjectSlcp dbresult = _dbContext.ProjectSlcp.Where(u => u.ClientProjectId == id).FirstOrDefault();


                if (dbresult != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        dbresult.IsDeleted = true;
                        Project.IsDeleted = true;


                        Project.ProjectSlcp.Add(dbresult);
                        await base.UpdateAsync(Project);
                        await _unitOfWork.SaveChangesAsync();





                        transaction.Commit();


                        return "Successfully Deleted!";

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Not Deleted!";
                    }
                }
                else
                {
                    return "User Academic not Exists!";
                }


            }
            // return "User Already Exists!";
        }
        public async Task<ProjectSLCPModel> DownloadFile(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectSlcp DbLibrary = await Task.Run(() => _dbContext.ProjectSlcp.Where(x => x.ClientProjectId == id).FirstOrDefault());

                ProjectSLCPModel Li = new ProjectSLCPModel();
                if (DbLibrary != null)
                {
                    Li.ApplicationFormPath = DbLibrary.ApplicationFormPath;
                    Li.ApplicationContentType = DbLibrary.ApplicationContentType;

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                }
                return Li;
            }

        }
        public async Task<string> Approval(ProjectRemarksHistoryModel input)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {

                ProjectSlcp ProjectSA = _dbContext.ProjectSlcp.Where(u => u.ClientProjectId == input.Id).FirstOrDefault();
                ProjectRemarksHistory RemarksHistory = _dbContext.ProjectRemarksHistory.Where(u => u.Id == input.Id).FirstOrDefault();
                ClientProjects ClientProject = _dbContext.ClientProjects.Where(u => u.Id == input.Id).FirstOrDefault();
                ProjectRemarksHistory UserRemarksDb = new ProjectRemarksHistory();
                if (ClientProject != null && input.ApprovalStatusId > 0 && input.Remarks != null)
                {
                    try
                    {
                        UserRemarksDb.ApprovalStatusId = input.ApprovalStatusId;
                        UserRemarksDb.Remarks = input.Remarks;
                        UserRemarksDb.RemarksById = input.RemarksById;
                        UserRemarksDb.RemarksDate = DateTime.Now;
                        UserRemarksDb.ProjectId = input.ProjectId;
                        UserRemarksDb.IsDeleted = false;

                        ClientProject.ApprovalStatusId = input.ApprovalStatusId;
                        ClientProject.Remarks = input.Remarks;


                        ProjectSA.Remarks = input.Remarks;
                       // ProjectSA.ApprovalStatusId = input.ApprovalStatusId;

                        ClientProject.ProjectRemarksHistory.Add(UserRemarksDb);
                        ClientProject.ProjectSlcp.Add(ProjectSA);

                        //secuserEntity.AuthorizedBy=input.

                        ;


                        await base.UpdateAsync(ClientProject);
                        await _unitOfWork.SaveChangesAsync();

                        transaction.Commit();
                        return "Successfully Saved!";

                    }



                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Not Inserted!";
                    }



                }
                else
                {
                    return "Status And Remarks con not be Empty";
                }
            }

        }
        public async Task<string> SubmitForReview(long id, long loginUserId)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectRemarksHistory history = new ProjectRemarksHistory();
                ClientProjects ClientProject = _dbContext.ClientProjects.Where(u => u.Id == id).FirstOrDefault();
                ProjectSlcp Sa = _dbContext.ProjectSlcp.Where(u => u.ClientProjectId == id).FirstOrDefault();
                // ProjectRemarksHistory history = await Task.Run(() => _dbContext.ProjectRemarksHistory.Where(x => x.ProjectId == id).FirstOrDefault());
                if (ClientProject != null)
                {
                    if (Sa.ApplicationFormPath != null && Sa.ApplicationFormPath != "")
                    {
                        if (ClientProject.ApprovalStatusId != 6)
                        {
                           // Sa.ApprovalStatusId = 2;

                            history.ApprovalStatusId = 2;
                            ClientProject.ApprovalStatusId = 2;
                        }
                        else
                        {
                            //Sa.ApprovalStatusId = 4;

                            history.ApprovalStatusId = 4;
                            ClientProject.ApprovalStatusId = 4;
                        }
                        history.Remarks = ClientProject.Remarks;
                        history.RemarksById = ClientProject.LastModifiedById;
                        history.RemarksDate = DateTime.Now;
                        history.ProjectId = id;

                        history.IsDeleted = false;

                        ClientProject.ProjectRemarksHistory.Add(history);
                        ClientProject.ProjectSlcp.Add(Sa);
                        await base.UpdateAsync(ClientProject);
                        await _unitOfWork.SaveChangesAsync();

                        transaction.Commit();
                        return "Successfully Record Send For Review !";
                    }
                    else {
                        return "Please Upload Application Form !";
                    }
                }
                else
                {
                    return "Not Exists!";
                }
            }

        }



        public async Task<string> ContractSubmit(ClientProjectModel input)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectRemarksHistory history = new ProjectRemarksHistory();
                ClientProjects ClientProject = _dbContext.ClientProjects.Where(u => u.Id == input.Id).FirstOrDefault();

                // ProjectRemarksHistory history = await Task.Run(() => _dbContext.ProjectRemarksHistory.Where(x => x.ProjectId == id).FirstOrDefault());
                if (ClientProject != null)
                {
                    if (ClientProject.ApprovalStatusId != 8)
                    {
                        ClientProject.ApprovalStatusId = 9;

                        history.ApprovalStatusId = 9;

                    }
                    else
                    {


                        history.ApprovalStatusId = 10;
                        ClientProject.ApprovalStatusId = 10;
                    }

                    if (input.ContractForm != null)
                    {
                        string filename = Path.GetFileName(input.ContractForm.FileName);
                        string ContentType = input.ContractForm.ContentType;

                        string reportPath = _configuration["Reporting:ProjectsSLCPPath"];

                        // string newFileName = @"D:\Update work\LIbrary_Documents\" + +newid + "_" + filename;

                        string newFileName = reportPath + +input.Id + "_" + filename;
                        // string newFileName = @"G:\OzoneDocuments\LibraryDocument\" + +newid + "_" + filename;
                        using (var stream = new FileStream(newFileName, FileMode.Create))
                        {
                            await input.ContractForm.CopyToAsync(stream);

                        }

                        ClientProject.ContractFilePath = newFileName;
                        ClientProject.ContractFileContent = ContentType;


                    }
                    ClientProject.Remarks = input.Remarks;
                    history.Remarks = input.Remarks;
                    history.RemarksById = input.LastModifiedById;
                    history.RemarksDate = DateTime.Now;
                    history.ProjectId = input.Id;

                    history.IsDeleted = false;

                    ClientProject.ProjectRemarksHistory.Add(history);

                    await base.UpdateAsync(ClientProject);
                    await _unitOfWork.SaveChangesAsync();

                    transaction.Commit();
                    return "Successfully Contract Send For Review !";
                }
                else
                {
                    return "Not Submited!";
                }
            }

        }



        public async Task<string> ContractApproval(ClientProjectModel input)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                //ProjectLedger projectLedgerDbmod = new ProjectLedger();
                ProjectRemarksHistory history = new ProjectRemarksHistory();
                ClientProjects ClientProject = _dbContext.ClientProjects.Where(u => u.Id == input.Id).FirstOrDefault();
              var secuser  = _dbContext.SecUser.Where(u => u.Id == ClientProject.CreatedById).FirstOrDefault();
              
                if (ClientProject != null)
                {
                   // var dbprojectAmount = await Task.Run(() => _dbContext.ProjectAmount.Where(x => x.StandardId == ClientProject.StandardId && x.IsDeleted == false && x.OrganizationId== secuser.OrganizationId).OrderByDescending(x=>x.Id).FirstOrDefault());
                    //var dbprojectAmount1 = await Task.Run(() => _dbContext.projectLedger.Where(x => x.StandardId == ClientProject.StandardId && x.IsDeleted == false && x.OrganizationId == secuser.OrganizationId).OrderByDescending());

                   
                    history.ApprovalStatusId = input.ApprovalStatusId;
                    ClientProject.ApprovalStatusId = input.ApprovalStatusId;
                    ClientProject.Remarks = input.Remarks;
                    //if (dbprojectAmount != null)
                    //{
                    //    ClientProject.ProjectAmountId = dbprojectAmount.Id;
                    //}
                    //else
                    //{
                    //    return "2";
                    //}

                    //projectLedgerDbmod.Amount = input.Amount;
                    history.Remarks = input.Remarks;
                    history.RemarksById = input.LastModifiedById;

                    history.RemarksDate = DateTime.Now;
                    history.ProjectId = input.Id;

                    history.IsDeleted = false;

                    //projectLedgerDbmod.Amount = dbprojectAmount.Amount;
                    //projectLedgerDbmod.ProjectId = ClientProject.Id;
                    //projectLedgerDbmod.CreatedById = ClientProject.CreatedById;
                    //projectLedgerDbmod.LastModifiedById = ClientProject.LastModifiedById;
                    
                    //ClientProject.ProjectLedger.Add(projectLedgerDbmod);

                    ClientProject.ProjectRemarksHistory.Add(history);

                    await base.UpdateAsync(ClientProject);
                    await _unitOfWork.SaveChangesAsync();

                    transaction.Commit();
                    //return "Successfully Saved !";
                    return "1";
                }
                else
                {
                    //return "Not Submited!";
                    return "0";
                }
            }

        }

        

       public async Task<ClientProjectModel> downloadContract(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ClientProjects DbLibrary = await Task.Run(() => _dbContext.ClientProjects.Where(x => x.Id == id).FirstOrDefault());

                ClientProjectModel Li = new ClientProjectModel();
                if (DbLibrary != null)
                {
                    Li.ContractFileContent = DbLibrary.ContractFileContent;
                    Li.ContractFilePath = DbLibrary.ContractFilePath;

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                }
                return Li;
            }

        }
    }
}