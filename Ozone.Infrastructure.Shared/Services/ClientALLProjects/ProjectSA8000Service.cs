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
  public  class ProjectSA8000Service : GenericRepositoryAsync<ClientProjects>, IProjectSA8000Service
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;

        public ProjectSA8000Service(
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
        private static bool newproject=true;
        public async Task<string> Create(ProjectSA8000CreateModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectRemarksHistory  history= new ProjectRemarksHistory();
                ClientProjects Dbproject = null;
                ProjectSa8000 DbResult = null;
                 Dbproject = await Task.Run(() => _dbContext.ClientProjects.Where(x => x.Id == input.Id && x.IsDeleted == false).FirstOrDefault());
                if (Dbproject != null)
                { 
                    DbResult = await Task.Run(() => _dbContext.ProjectSa8000.Where(x => x.ClientProjectId == Dbproject.Id && x.IsDeleted == false).FirstOrDefault()); 
                }

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if ( Dbproject==null)
                    {
                        New = true;
                        Dbproject = new ClientProjects();
                        DbResult = new ProjectSa8000();
                        Dbproject.Date = DateTime.Now;

                        Dbproject.StandardId = input.StandardId;
                        Dbproject.ApprovalStatusId = 6;
                        Dbproject.ClientId = input.ClientId;
                        Dbproject.ProjectCode= GetProgectCode(input.ClientSiteId, Dbproject.StandardId,input.ClientId);
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
                    if (input.ClientSiteId > 0)
                    {
                        Dbproject.ClientSiteId = input.ClientSiteId;
                    }
                    // Dbproject.StandardId = 7;
                    if (input.VerificationTypeId > 0)
                    {
                        Dbproject.VerificationTypeId = input.VerificationTypeId;
                    }

                   


                    Dbproject.Remarks = input.Remarks;


                    DbResult.Code = input.Code;
                   // DbResult.ProjectTypeId = input.ProjectTypeId;
                    DbResult.RiskId = input.RiskId;
                    DbResult.EacodeId = input.EacodeId;
                    DbResult.NaceCodeId = input.NaceCodeId;
                    DbResult.ConsultantId = input.ConsultantId;
                    DbResult.AccreditationId = input.AccreditationId;
                    DbResult.Scope = input.Scope;
                    DbResult.PreAuditDuration = input.PreAuditDuration;
                    DbResult.DurationStage1 = input.DurationStage1;
                    DbResult.DurationStage2 = input.DurationStage2;
                    DbResult.SurveillanceMethodId = input.SurveillanceMethodId;
                    DbResult.SurveillanceVisitFrequencyId = input.SurveillanceVisitFrequencyId;
                    DbResult.NoOfSurveillanceVisits = input.NoOfSurveillanceVisits;
                    DbResult.Applicatonfee = input.Applicatonfee;
                    DbResult.PreAuditfee = input.PreAuditfee;
                    DbResult.Assessmentfee = input.Assessmentfee;
                    DbResult.Survfee = input.Survfee;
                    DbResult.ExpensesId = input.ExpensesId;
                  
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
                        Dbproject.ProjectSa8000.Add(DbResult);
                        await base.AddAsync(Dbproject);
                        //message = "Successfully Inserted!";
                        message = "1";
                    }
                    else
                    {
                        DbResult.LastModifiedById = input.LastModifiedById;
                        DbResult.LastModifiedDate =DateTime.Now;
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

                        // message = "Successfully Updated!";
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

                        string reportPath = _configuration["Reporting:ProjectsSA8000Path"];

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
                    var Exception = ex;
                    transaction.Rollback();
                    return "0";
                }



            }

        }

        public string GetProgectCode(long clientSiteId, long standardId ,long? ClientId)
        {

            //int? cmpid = 0;
            string Codelast = string.Empty;
            int newNO = 0;
            string ItemCode = string.Empty;
            string re = "-";
           // string code = "CAT-";

            var AgencyCode = "";
            var ClientCode = "";
            var clientSiteCode = "";
            var StandardCode = "";
            DateTime Date = System.DateTime.Now;
            string date = Date.ToString("yy");
            var standard = new Certification();
            var ClientProjectMod = new ClientProjectModel();
            var ClientSitesModel = new ClientSitesModel();
            var clientMod = new ClientModel();
            if (clientSiteId > 0)
            {
                var ClientProject = _dbContext.ClientProjects.Include(x => x.ClientSite).Include(x => x.Standard).Include(x => x.ClientSite.Client).Include(x => x.ClientSite.Client.Organization).Where(x => x.StandardId == standardId && x.ClientSiteId == clientSiteId && x.IsDeleted==false && x.ClientId==ClientId).OrderByDescending(a => a.Id).FirstOrDefault();
                ClientProjectMod = _mapper.Map<ClientProjectModel>(ClientProject);
            }
            else
            {
               
                

                var ClientProject = _dbContext.ClientProjects.Where(x => x.StandardId == standardId && x.ClientId==ClientId).OrderByDescending(a => a.Id).FirstOrDefault();
                ClientProjectMod = _mapper.Map<ClientProjectModel>(ClientProject);
            }
            standard = _dbContext.Certification.Where(x => x.Id == standardId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            var client = _dbContext.Client.Include(x => x.Organization).Where(x => x.Id == ClientId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            clientMod = _mapper.Map<ClientModel>(client);
            if (ClientProjectMod != null) 
            
            {
                newproject = false;


                if (clientSiteId > 0)
                {


                    clientSiteCode = ClientProjectMod.ClientSiteCode.Substring(0, 3);

                    AgencyCode = ClientProjectMod.AgencyCode.Substring(0, 3);

                    ClientCode = ClientProjectMod.ClientCode.Substring(4, 3);

                    StandardCode = ClientProjectMod.StandardCode;



                }

                else 
                {
                    clientSiteCode = "000";
                    AgencyCode = clientMod.OrganizationCode.Substring(0, 3);
                    ClientCode = clientMod.Code.Substring(4, 3);
                    StandardCode = standard.Code;
                }
               
               
                newNO = Convert.ToInt32(ClientProjectMod.ProjectCode.Substring(19,3));
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
                //clientSiteCode = ClientSitesModel.Code.Substring(0, 3);
                //AgencyCode = ClientSitesModel.AgencyCode.Substring(0, 3);
                //ClientCode= ClientSitesModel.ClientCode.Substring(4, 3);

                AgencyCode = clientMod.OrganizationCode.Substring(0, 3);
                ClientCode = clientMod.Code.Substring(4, 3);
                StandardCode = standard.Code;
                if (clientSiteId > 0)
                {


                    clientSiteCode = ClientSitesModel.Code.Substring(0, 3);

                  



                }

                else
                {
                    clientSiteCode = "000";
                   
                }
                StandardCode = _dbContext.Certification.Where(x => x.Id == standardId && x.IsDeleted == false).OrderByDescending(a => a.Id).Select(x=>x.Code).FirstOrDefault();
              
                ItemCode = AgencyCode + re + ClientCode + re + StandardCode + re + clientSiteCode + re + date + re  + "001";
            }
         

            return ItemCode;


        }

        public async Task<GetPagedClientProjectModel> GetProjectSA8000BYId(long id)
        {
           
            var result = new GetPagedClientProjectModel();
            var ProjectSAModel = new ProjectSA8000Model();
            var ClientProjectMod = new ClientProjectModel();
            var ClientSitesModel = new ClientSitesModel();
            var Dbresult = await Task.Run(() => _dbContext.ProjectSa8000.Where(x => x.ClientProjectId == id).FirstOrDefault());
            ProjectSAModel = _mapper.Map<ProjectSA8000Model>(Dbresult);
            var Dbresult2 = await Task.Run(() => _dbContext.ClientProjects.Include(x=>x.ClientSite).Include(x=>x.Client).Include(x=>x.ApprovalStatus).Where(x => x.Id == id).FirstOrDefault());
            ClientProjectMod = _mapper.Map<ClientProjectModel>(Dbresult2);
            var Dbresult3 = await Task.Run(() => _dbContext.ClientSites.Where(x => x.Id == Dbresult2.ClientSiteId).FirstOrDefault());
            ClientSitesModel = _mapper.Map<ClientSitesModel>(Dbresult3);
            //var Dbresult3 = await Task.Run(() => _dbContext.ClientSites.Where(x => x.Id == Dbresult2.ClientSiteId).FirstOrDefault());
            //ClientSitesModel = _mapper.Map<ClientSitesModel>(Dbresult3);


            result.ProjectSA8000Model = ProjectSAModel;
            result.ClientProjectModel = ClientProjectMod;
            result.ClientSitesModel = ClientSitesModel;

            return result;
        }

        private List<ProjectSA8000Model> GetPage(List<ProjectSA8000Model> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedProjectSA8000Model> GetPagedProjectSA8000(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedProjectSA8000Model();
                var UserStdList = new List<ProjectSA8000Model>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();

                var list = await _dbContext.ProjectSa8000.Where(x => x.IsDeleted == false).ToListAsync();
                UserStdList = _mapper.Map<List<ProjectSA8000Model>>(list);
                // return list;
                //}


                //else
                //{
                //    var list = await _dbContext.Certification.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //                 (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //                x.Code.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //    productDenoList = _mapper.Map<List<StandardModel>>(list);
                //    // return list;
                //}
                //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

                result.ProjectSA8000Model = GetPage(UserStdList, model.Page, model.PageSize);
                result.TotalCount = UserStdList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> ProjectSA8000DeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {

                ClientProjects Project= _dbContext.ClientProjects.Where(u => u.Id == id).FirstOrDefault();
                ProjectSa8000 dbresult = _dbContext.ProjectSa8000.Where(u => u.ClientProjectId == id).FirstOrDefault();


                if (dbresult != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        dbresult.IsDeleted = true;
                        Project.IsDeleted = true;


                        Project.ProjectSa8000.Add(dbresult);
                        await base.UpdateAsync(Project);
                        await _unitOfWork.SaveChangesAsync();





                        transaction.Commit();


                        return "Successfully Deleted!";

                    }
                    catch (Exception ex)
                    {
                        var Exception = ex;
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
        public async Task<ProjectSA8000Model> DownloadFile(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectSa8000 DbLibrary = await Task.Run(() => _dbContext.ProjectSa8000.Where(x => x.ClientProjectId == id).FirstOrDefault());

                ProjectSA8000Model Li = new ProjectSA8000Model();
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

                ProjectSa8000 ProjectSA = _dbContext.ProjectSa8000.Where(u => u.ClientProjectId == input.Id).FirstOrDefault();
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
                        //ProjectSA.ApprovalStatusId = input.ApprovalStatusId;

                        ClientProject.ProjectRemarksHistory.Add(UserRemarksDb);
                        ClientProject.ProjectSa8000.Add(ProjectSA);

                        //secuserEntity.AuthorizedBy=input.
                   
;

               
                    await base.UpdateAsync(ClientProject);
                    await _unitOfWork.SaveChangesAsync();

                    transaction.Commit();
                    return "Successfully Saved!";

                    }



                    catch (Exception ex)
                    {
                        var Exception = ex;
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
        public async Task<string> SubmitForReview(long id,long loginUserId)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectRemarksHistory history = new ProjectRemarksHistory();
                ClientProjects ClientProject = _dbContext.ClientProjects.Where(u => u.Id == id).FirstOrDefault();
                ProjectSa8000 Sa = _dbContext.ProjectSa8000.Where(u => u.ClientProjectId == id).FirstOrDefault();
               // ProjectRemarksHistory history = await Task.Run(() => _dbContext.ProjectRemarksHistory.Where(x => x.ProjectId == id).FirstOrDefault());
                if (ClientProject != null)
                {

                 
                        if (ClientProject.ApprovalStatusId != 6)
                    {
                        //Sa.ApprovalStatusId = 2;

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
                    history.ProjectId =id;

                    history.IsDeleted = false;
                  
                    ClientProject.ProjectRemarksHistory.Add(history);
                    //ClientProject.ProjectSa8000.Add(Sa);
                    await base.UpdateAsync(ClientProject);
                    await _unitOfWork.SaveChangesAsync();

                    transaction.Commit();
                    return "Successfully Record Send For Review !";
                }
                else
                {
                    return "Reques Not Send For Approval";
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

                        string reportPath = _configuration["Reporting:ProjectsSA8000Path"];

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
    }
}
