using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Setup;
using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozone.Application.DTOs.Projects;

namespace Ozone.Infrastructure.Shared.Services
{
   public class ProjectAmountReportsService : GenericRepositoryAsync<ProjectLedgerDetail>, IProjectAmountReportsService
    {


        private readonly OzoneContext _dbContext;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectAmountReportsService(
        IUnitOfWork unitOfWork,
        OzoneContext dbContext,
        IMapper mapper,
        IUserSessionHelper userSession) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            this._mapper = mapper;
            this._userSession = userSession;
        }


        private List<ProjectLedgerModel> GetPage(List<ProjectLedgerModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        private List<ProjectLedgerDetailModel> GetPage(List<ProjectLedgerDetailModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<List<OrganizationModel>> GetAllAgency()
        {
            var result = new List<OrganizationModel>();
            var list = await Task.Run(() => _dbContext.Organization.Where(x => x.IsActive == true && x.OrganizationTypeId == 2).ToList());
            result = _mapper.Map<List<OrganizationModel>>(list);
            return result;
        }

        //public async Task<GetPagedProjectAmountReportsModel> GetPagedProjectAmountReports(PagedResponseModel model)
        //{
        //    try
        //    {
        //        var result = new GetPagedProjectAmountReportsModel();
        //        var projectDenoList = new List<ClientProjectModel>();
        //        var list1 = await Task.Run(() =>  _dbContext.ClientProjects.Include(x => x.ClientSite).Include(x => x.Standard).Include(x => x.ClientSite.Client).Include(x => x.ClientSite.Client.Organization).Include(x => x.ProjectAmount).Where(x => x.IsDeleted == false && x.ProjectAmount.OrganizationId == model.organizationId || x.StandardId == model.standardId).ToList());
        //       // var list1 = await Task.Run(() => _dbContext.ClientProjects.Include(x => x.ProjectAmount).Include(x => x.Standard).Where(x => x.IsDeleted == false&& x.ProjectAmount.OrganizationId==model.organizationId || x.StandardId==model.standardId).ToList());
        //        // list = await Task.Run(() => _dbContext.ProjectAmount.Include(x => x.Organization).Include(x => x.Standard).Where(x => x.IsDeleted == false).ToList());
        //        projectDenoList = _mapper.Map<List<ClientProjectModel>>(list1);
        //        result.ProjectAmountModel = GetPage(projectDenoList, model.Page, model.PageSize);
        //        result.TotalCount = projectDenoList.Count();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public async Task<GetPagedProjectLedgerModel> GetPagedProjectLedger(PagedResponseModel model)
        {
            try
            {
                var result = new GetPagedProjectLedgerModel();
                var ProjectLedgerList = new List<ProjectLedgerModel>();
                var list1 = await Task.Run(() => _dbContext.ProjectLedger.Include(x => x.Project.ClientSite).Include(x => x.Project.Standard).Include(x => x.Project.Client).Include(x => x.Project.Client.Organization).Include(x=>x.ProjectLedgerDetail).Where(x => x.Project.Client.OrganizationId == model.organizationId && x.Project.StandardId == model.standardId).ToList());
                // var list1 = await Task.Run(() => _dbContext.ClientProjects.Include(x => x.ProjectAmount).Include(x => x.Standard).Where(x => x.IsDeleted == false&& x.ProjectAmount.OrganizationId==model.organizationId || x.StandardId==model.standardId).ToList());
                // list = await Task.Run(() => _dbContext.ProjectAmount.Include(x => x.Organization).Include(x => x.Standard).Where(x => x.IsDeleted == false).ToList());
                ProjectLedgerList = _mapper.Map<List<ProjectLedgerModel>>(list1);
                result.ProjectLedgerModel = GetPage(ProjectLedgerList, model.Page, model.PageSize);
                result.TotalCount = ProjectLedgerList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<GetPagedProjectLedgerDetailModel> GetPagedProjectLedgerDetail(long id,PagedResponseModel model)
        {
            try
            {
                
                var result = new GetPagedProjectLedgerDetailModel();
                var ProjectLedgerList = new List<ProjectLedgerDetailModel>();
                var list1 = await Task.Run(() => _dbContext.ProjectLedgerDetail.Where(x=>x.ProjectLedgerMasterId==id).ToList());
                var projectAmount = await Task.Run(() => _dbContext.ProjectLedger.Include(x => x.Project.ClientSite).Where(x=>x.Id==id).Select(x=>x.Amount).FirstOrDefaultAsync());
                // list = await Task.Run(() => _dbContext.ProjectAmount.Include(x => x.Organization).Include(x => x.Standard).Where(x => x.IsDeleted == false).ToList());
                ProjectLedgerList = _mapper.Map<List<ProjectLedgerDetailModel>>(list1);

                ProjectLedgerList.Sum(x => x.ReceiveAmount);

                result.ProjectLedgerDetailModel = GetPage(ProjectLedgerList, model.Page, model.PageSize);
                result.TotalReceivedAmount= ProjectLedgerList.Sum(x => x.ReceiveAmount);
                result.InvoiceAmount = projectAmount;
                result.BalanceAmount = projectAmount - result.TotalReceivedAmount;

                result.TotalCount = ProjectLedgerList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<string> Create(ProjectLedgerDetailModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectLedgerDetail DbLedgerDetail = await Task.Run(() => _dbContext.ProjectLedgerDetail.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbLedgerDetail == null)
                    {
                        New = true;
                        DbLedgerDetail = new ProjectLedgerDetail();
                    }
                    //DbModules.Id = input.Id;
                    DbLedgerDetail.ReceiveAmount = input.ReceiveAmount;
                    DbLedgerDetail.Date = input.Date;
                    DbLedgerDetail.ProjectLedgerMasterId = input.ProjectLedgerMasterId;
                    
                    //DbLegislation.CreatedBy = input.CreatedBy;


                    if (New == true)
                    {
                       DbLedgerDetail.IsDeleted = false;
                        await base.AddAsync(DbLedgerDetail);
                    }
                    else
                    {
                        await base.UpdateAsync(DbLedgerDetail);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbLedgerDetail.Id;

                    transaction.Commit();
                    return "Successfully Saved!";

                }
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "Not Inserted!";
                }



            }

        }



        //public async Task<string> ProjectAmountReportsDeleteById(long id)
        //{
        //    // OzoneContext ozonedb = new OzoneContext();
        //    using (var transaction = _unitOfWork.BeginTransaction())
        //    {


        //        projectLedger DbProjectLedger = _dbContext.projectLedger.Where(u => u.Id == id).FirstOrDefault();


        //        if (DbStandard != null)
        //        {
        //            // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

        //            try
        //            {


        //                DbStandard.IsDeleted = true;
        //                await base.UpdateAsync(DbStandard);
        //                await _unitOfWork.SaveChangesAsync();





        //                transaction.Commit();


        //                return "Successfully Deleted!";

        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                return "Not Deleted!";
        //            }
        //        }
        //        else
        //        {
        //            return "Client not Exists!";
        //        }


        //    }
        //    // return "User Already Exists!";
        //}

    }
}
