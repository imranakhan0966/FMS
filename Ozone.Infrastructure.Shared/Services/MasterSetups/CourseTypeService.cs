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
  public  class CourseTypeService : GenericRepositoryAsync<CourseType>, ICourseTypeService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public CourseTypeService(
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

        public async Task<string> Create(CourseTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                CourseType DbCourse = await Task.Run(() => _dbContext.CourseType.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbCourse == null)
                    {
                        New = true;
                        DbCourse = new CourseType();
                    }
                    //DbModules.Id = input.Id;
                    DbCourse.Id = input.Id;
                    DbCourse.Name = input.Name;
                    DbCourse.IsActive = input.IsActive;
                    DbCourse.Description = input.Description;
                   // DbCourse.Address = input.Address;
                    DbCourse.Code = input.Code;
                    DbCourse.CreatedBy = input.CreatedBy;


                    if (New == true)
                    {
                        DbCourse.IsDeleted = false;
                        await base.AddAsync(DbCourse);
                    }
                    else
                    {
                        await base.UpdateAsync(DbCourse);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbCourse.Id;

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

        public async Task<string> CourseTypeDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                CourseType DbCourse = _dbContext.CourseType.Where(u => u.Id == id).FirstOrDefault();


                if (DbCourse != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbCourse.IsDeleted = true;
                        await base.UpdateAsync(DbCourse);
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

        public async Task<CourseTypeModel> GetCourseTypeBYId(long id)
        {
            var result = new CourseTypeModel();
            var DbCourse = await Task.Run(() => _dbContext.CourseType.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<CourseTypeModel>(DbCourse);
            return result;
        }

        private List<CourseTypeModel> GetPage(List<CourseTypeModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedCourseTypeModel> GetPagedCourseTypeResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedCourseTypeModel();
                var productDenoList = new List<CourseTypeModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.CourseType.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<CourseTypeModel>>(list);
                //}


                //else
                //{
                //    var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //                 (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //                x.Code.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //    productDenoList = _mapper.Map<List<ModulesModel>>(list);
                //    // return list;
                //}
                //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

                result.CourseTypeModel = GetPage(productDenoList, model.Page, model.PageSize);
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
