using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;

//using Ozone.Application.DTOs.Library;
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
  public  class EaCodeService : GenericRepositoryAsync<Eacode>, IEaCodeService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public EaCodeService(
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

        public async Task<string> Create(EACodeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Eacode DbEaCode = await Task.Run(() => _dbContext.Eacode.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {

                    var message = "";
                    long newid;
                    bool New = false;
                    if (DbEaCode == null)
                    {
                        New = true;
                        DbEaCode = new Eacode();
                    }
                    //DbModules.Id = input.Id;
                    DbEaCode.Id = input.Id;
                    DbEaCode.Name = input.Name;
                    DbEaCode.IsActive = input.IsActive;
                    DbEaCode.Description = input.Description;

                    DbEaCode.Code = input.Code;
                    DbEaCode.CreatedBy = input.CreatedBy;


                    if (New == true)
                    {
                        DbEaCode.IsDeleted = false;
                        await base.AddAsync(DbEaCode);
                        message = "Successfully Inserted!";
                    }
                    else
                    {
                        await base.UpdateAsync(DbEaCode);
                        message = "Successfully Updated!";
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbEaCode.Id;

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

        public async Task<string> EaCodeDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Eacode DbEaCode = _dbContext.Eacode.Where(u => u.Id == id).FirstOrDefault();


                if (DbEaCode != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbEaCode.IsDeleted = true;
                        await base.UpdateAsync(DbEaCode);
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

        public async Task<EACodeModel> GetEaCodeBYId(long id)
        {
            var result = new EACodeModel();
            var DbEaCode = await Task.Run(() => _dbContext.Eacode.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<EACodeModel>(DbEaCode);
            return result;
        }

        private List<EACodeModel> GetPage(List<EACodeModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedEaCodeModel> GetPagedEaCodeResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedEaCodeModel();
                var productDenoList = new List<EACodeModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.Eacode.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<EACodeModel>>(list);
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

                result.EaCodeModel = GetPage(productDenoList, model.Page, model.PageSize);
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
