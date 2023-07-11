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
   public class StandardTypeService : GenericRepositoryAsync<StandardType>, IStandardTypeService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public StandardTypeService(
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

        public async Task<string> Create(StandardTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                StandardType DbStandard = await Task.Run(() => _dbContext.StandardType.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if (DbStandard == null)
                    {
                        New = true;
                        DbStandard = new StandardType();
                    }
                    //DbModules.Id = input.Id;
                    DbStandard.Id = input.Id;
                    DbStandard.Name = input.Name;
                    DbStandard.IsActive = input.IsActive;
                    DbStandard.Description = input.Description;

                    DbStandard.Code = input.Code;
                    DbStandard.CreatedById = input.CreatedBy;


                    if (New == true)
                    {
                        DbStandard.IsDeleted = false;
                        await base.AddAsync(DbStandard);
                        message = "Successfully Saved!";
                    }
                    else
                    {
                        await base.UpdateAsync(DbStandard);
                        message="Successfully Updated!";
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                   // newid = DbStandard.Id;

                    transaction.Commit();
                    return message;

                }

                catch
                {
                    transaction.Rollback();
                    return "Not Inserted!";
                }



            }

        }

        public async Task<string> StandardTypeDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                StandardType DbStandard = _dbContext.StandardType.Where(u => u.Id == id).FirstOrDefault();


                if (DbStandard != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbStandard.IsDeleted = true;
                        await base.UpdateAsync(DbStandard);
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


        public async Task<StandardTypeModel> GetStandardTypeBYId(long id)
        {
            var result = new StandardTypeModel();
            var DbStandard = await Task.Run(() => _dbContext.StandardType.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<StandardTypeModel>(DbStandard);
            return result;
        }

        private List<StandardTypeModel> GetPage(List<StandardTypeModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedStandardTypeModel> GetPagedStandardTypeResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedStandardTypeModel();
                var productDenoList = new List<StandardTypeModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.StandardType.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<StandardTypeModel>>(list);
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

                result.StandardTypeModel = GetPage(productDenoList, model.Page, model.PageSize);
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

