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

namespace Ozone.Infrastructure.Shared.Services
{
    public class ProjectAmountSevice : GenericRepositoryAsync<ProjectAmount>, IProjectAmountService
    {
        private readonly OzoneContext _dbContext;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectAmountSevice(
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

        public async Task<string> Create(ProjectAmountModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectAmount DbProjectAmount = await Task.Run(() => _dbContext.ProjectAmount.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());
                try
                {
                    long newid;
                    bool New = false;
                    if (DbProjectAmount == null)
                    {
                        New = true;
                        DbProjectAmount = new ProjectAmount();
                    }

                    DbProjectAmount.Id = input.Id;
                    DbProjectAmount.Code = input.Code;
                    DbProjectAmount.IsActive = input.IsActive;

                    DbProjectAmount.Description = input.Description;
                    DbProjectAmount.OrganizationId = input.OrganizationId;
                    DbProjectAmount.StandardId = input.StandardId;
                    DbProjectAmount.Date = input.Date;
                    DbProjectAmount.Amount = input.Amount;




                    if (New == true)
                    {
                        DbProjectAmount.CreatedDate = DateTime.Now;
                        DbProjectAmount.CreatedBy = input.CreatedBy;
                        DbProjectAmount.IsDeleted = false;
                        await base.AddAsync(DbProjectAmount);
                    }
                    else
                    {
                        DbProjectAmount.LastupdatedDate = DateTime.Now;
                        DbProjectAmount.LastupdatedId = input.LastupdatedId;
                        await base.UpdateAsync(DbProjectAmount);
                    }

                    var result = await _unitOfWork.SaveChangesAsync();
                    newid = DbProjectAmount.Id;
                    transaction.Commit();
                    return "Successfully Saved!";
                }

                catch
                {
                    transaction.Rollback();
                    return "Not Inserted!";
                }
            }
        }




        public async Task<string> ProjectAmountDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                ProjectAmount DbProjectAmount = _dbContext.ProjectAmount.Where(u => u.Id == id).FirstOrDefault();
                if (DbProjectAmount != null)
                {
                    try
                    {
                        DbProjectAmount.IsDeleted = true;
                        await base.UpdateAsync(DbProjectAmount);
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
                    return "Client not Exists!";
                }
            }
        }

        public async Task<ProjectAmountModel> GetProjectAmountBYId(long id)
        {
            var result = new ProjectAmountModel();
            var DbProjectAmount = await Task.Run(() => _dbContext.ProjectAmount.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<ProjectAmountModel>(DbProjectAmount);
            return result;
        }

        private List<ProjectAmountModel> GetPage(List<ProjectAmountModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }


        public async Task<GetPagedProjectAmountModel> GetPagedProjectAmountResponse(PagedResponseModel model)
        {
            try
            {
                var result = new GetPagedProjectAmountModel();
                var projectDenoList = new List<ProjectAmountModel>();
                var list = await Task.Run(() => _dbContext.ProjectAmount.Include(x => x.Organization).Include(x => x.Standard).Where(x => x.IsDeleted == false).ToList());
                projectDenoList = _mapper.Map<List<ProjectAmountModel>>(list);
                result.ProjectAmountModel = GetPage(projectDenoList, model.Page, model.PageSize);
                result.TotalCount = projectDenoList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<OrganizationModel>> GetAllAgency()
        {
            var result = new List<OrganizationModel>();

            var list = await Task.Run(() => _dbContext.Organization.Where(x => x.IsActive == true && x.OrganizationTypeId == 2).ToList());
            result = _mapper.Map<List<OrganizationModel>>(list);
            return result;
        }
    }
}
