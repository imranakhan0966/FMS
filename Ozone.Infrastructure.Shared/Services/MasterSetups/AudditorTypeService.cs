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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
   public class AudditorTypeService : GenericRepositoryAsync<AuditorTypes>, IAudditorTypeService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public AudditorTypeService(
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

        public async Task<string> Create(AudditorTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                AuditorTypes DbAudditor = await Task.Run(() => _dbContext.AuditorTypes.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if (DbAudditor == null)
                    {
                        New = true;
                        DbAudditor = new AuditorTypes();
                    }
                    //DbModules.Id = input.Id;
                    DbAudditor.Id = input.Id;
                    DbAudditor.Name = input.Name;
                    DbAudditor.IsActive = input.IsActive;
                    DbAudditor.Description = input.Description;
                    //DbAudditor.Address = input.Address;
                    DbAudditor.Code = input.Code;
                    DbAudditor.CreatedBy = input.CreatedBy;


                    if (New == true)
                    {
                        DbAudditor.IsDeleted = false;
                        await base.AddAsync(DbAudditor);
                        message= "Successfully Inserted!";
                    }
                    else
                    {
                        await base.UpdateAsync(DbAudditor);
                        message = "Successfully Updated!";
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbAudditor.Id;

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

        public async Task<string> AudditorTypeDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                AuditorTypes DbAudditor = _dbContext.AuditorTypes.Where(u => u.Id == id).FirstOrDefault();


                if (DbAudditor != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbAudditor.IsDeleted = true;
                        await base.UpdateAsync(DbAudditor);
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

        public async Task<AudditorTypeModel> GetAudditorTypeBYId(long id)
        {
            var result = new AudditorTypeModel();
            var DbAudditor = await Task.Run(() => _dbContext.AuditorTypes.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<AudditorTypeModel>(DbAudditor);
            return result;
        }

        private List<AudditorTypeModel> GetPage(List<AudditorTypeModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedAudditorTypeModel> GetPagedAudditorTypeResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedAudditorTypeModel();
                var productDenoList = new List<AudditorTypeModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.AuditorTypes.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<AudditorTypeModel>>(list);
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

                result.AudditorTypeModel = GetPage(productDenoList, model.Page, model.PageSize);
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

