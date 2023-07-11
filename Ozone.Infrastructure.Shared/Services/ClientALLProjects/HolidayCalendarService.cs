using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System.Linq;
using System.Threading.Tasks;
//using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ozone.Infrastructure.Shared.Services
{
    public class HolidayCalendarService : GenericRepositoryAsync<HolidayCalendar>, IHolidayCalendarService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public HolidayCalendarService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        IUserSessionHelper userSession) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._userSession = userSession;
            //_mockData = mockData;
        }

        public async Task<string> Create(HolidayCalendarModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                HolidayCalendar DbHolidayCalendar = await Task.Run(() => _dbContext.HolidayCalendar.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {

                    bool New = false;
                    if (DbHolidayCalendar == null)
                    {
                        New = true;
                        DbHolidayCalendar = new HolidayCalendar();
                    }
                    //DbModules.Id = input.Id;
                    //DbHolidayCalendar.Id = input.Id;
                    DbHolidayCalendar.Date = input.Date;
                    DbHolidayCalendar.Description = input.Description;
                    //DbHolidayCalendar.CreatedBy = input.CreatedBy;
                    DbHolidayCalendar.HolidayTypeId = input.HolidayTypeId;
                    DbHolidayCalendar.OrganizationId = input.OrganizationId;




                    if (New == true)
                    {
                        DbHolidayCalendar.CreatedBy = input.CreatedBy;

                        DbHolidayCalendar.IsDeleted = false;
                        await base.AddAsync(DbHolidayCalendar);
                    }
                    else
                    {

                        DbHolidayCalendar.LastModifiedBy = input.LastModifiedBy;
                        DbHolidayCalendar.LastModifiedDate = input.LastModifiedDate;

                        await base.UpdateAsync(DbHolidayCalendar);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    //newid = DbAccreditation.Id;

                    transaction.Commit();
                    return "Successfully Saved!";

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "Not Inserted!";
                }




            }

        }

        public async Task<string> HolidayCalendarDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                HolidayCalendar DbHolidayCalendar = _dbContext.HolidayCalendar.Where(u => u.Id == id).FirstOrDefault();


                if (DbHolidayCalendar != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbHolidayCalendar.IsDeleted = true;
                        await base.UpdateAsync(DbHolidayCalendar);
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
            // return "User Already Exists!";
        }

        public async Task<HolidayCalendarModel> GetHolidayCalendarBYId(long id)
        {
            var result = new Application.DTOs.HolidayCalendarModel();
            var DbHolidayCalendar = await Task.Run(() => _dbContext.HolidayCalendar.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<HolidayCalendarModel>(DbHolidayCalendar);
            return result;
        }

        private List<HolidayCalendarModel> GetPage(List<HolidayCalendarModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedHolidayCalendarModel> GetPagedHolidayCalendarResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedHolidayCalendarModel();
                var productDenoList = new List<HolidayCalendarModel>();
                if (model.organizationId == 1)
                {
                    var list = await Task.Run(() => _dbContext.HolidayCalendar.Include(x => x.HolidayType).Where(x => x.IsDeleted == false).ToList());
                    productDenoList = _mapper.Map<List<HolidayCalendarModel>>(list);
                }
                else
                {
                    var list = await Task.Run(() => _dbContext.HolidayCalendar.Include(x => x.HolidayType).Where(x => x.IsDeleted == false && x.OrganizationId==model.organizationId).ToList());
                    productDenoList = _mapper.Map<List<HolidayCalendarModel>>(list);
                }
                result.HolidayCalendarModel = GetPage(productDenoList, model.Page, model.PageSize);
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
