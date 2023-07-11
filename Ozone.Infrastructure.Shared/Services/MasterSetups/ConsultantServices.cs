using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
    public class ConsultantService : GenericRepositoryAsync<Consultant>, IConsultantService
    {
        private readonly OzoneContext _dbContext;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        private readonly IUnitOfWork _unitOfWork;

        public ConsultantService(
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

        public async Task<string> Create(ConsultantModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Consultant DbConsultant = await Task.Run(() => _dbContext.Consultant.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());
                try
                {
                    long newid;
                    bool New = false;
                    if (DbConsultant == null)
                    {
                        New = true;
                        DbConsultant = new Consultant();
                        DbConsultant.OrganizationId = input.OrganizationId;
                    }

                    DbConsultant.Id = input.Id;
                    DbConsultant.Code = input.Code;
                    DbConsultant.Name = input.Name;
                    DbConsultant.Email = input.Email;
                    DbConsultant.PhoneNumber = input.PhoneNumber;
                    DbConsultant.TellNumber = input.TellNumber;
                    DbConsultant.Address = input.Address;
                    DbConsultant.CityId = input.CityId;
                    DbConsultant.CountryId = input.CountryId;
                    DbConsultant.StateId = input.StateId;
                    DbConsultant.OrganizationId = input.OrganizationId;
                    DbConsultant.PrefixId = input.PrefixId;
                    DbConsultant.CreatedById = input.CreatedById;
                    DbConsultant.CreatedDate = input.CreatedDate;
                    DbConsultant.LastUpdatedId = input.LastUpdatedId;
                    DbConsultant.LastUpdatedDate = input.LastUpdatedDate;

                    DbConsultant.IsActive = input.IsActive;
                    if (New == true)
                    {
                        DbConsultant.IsDeleted = false;
                        await base.AddAsync(DbConsultant);
                    }
                    else
                    {
                        await base.UpdateAsync(DbConsultant);
                    }
                    var result = await _unitOfWork.SaveChangesAsync();
                    newid = DbConsultant.Id;
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




        public async Task<string> ConsultantDeleteById(long id)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Consultant DbConsultant = _dbContext.Consultant.Where(u => u.Id == id).FirstOrDefault();
                if (DbConsultant != null)
                {
                    try
                    {
                        DbConsultant.IsDeleted = true;
                        await base.UpdateAsync(DbConsultant);
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



        public async Task<ConsultantModel> GetConsultantBYId(long id)
        {
            var result = new ConsultantModel();
            var DbConsultant = await Task.Run(() => _dbContext.Consultant.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<ConsultantModel>(DbConsultant);
            return result;
        }



        private List<ConsultantModel> GetPage(List<ConsultantModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }


        public async Task<GetPagedConsultantModel> GetPagedConsultantResponse(PagedResponseModel model)
        {
            try
            {
                var result = new GetPagedConsultantModel();
                var productDenoList = new List<ConsultantModel>();
                var list = await Task.Run(() => _dbContext.Consultant.Where(x => x.IsDeleted == false && x.OrganizationId== model.organizationId).ToList());
                productDenoList = _mapper.Map<List<ConsultantModel>>(list);
                result.ConsultantModel = GetPage(productDenoList, model.Page, model.PageSize);
                result.TotalCount = productDenoList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
