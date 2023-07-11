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
    public class NaceCodeService : GenericRepositoryAsync<NaceCode>, INaceCodeService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public NaceCodeService(
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

        public async Task<string> Create(NaceCodeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                NaceCode DbNaceCode = await Task.Run(() => _dbContext.NaceCode.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if (DbNaceCode == null)
                    {
                        New = true;
                        DbNaceCode = new NaceCode();
                    }
                    //DbModules.Id = input.Id;
                    DbNaceCode.Id = input.Id;
                    DbNaceCode.Name = input.Name;
                    DbNaceCode.IsActive = input.IsActive;
                    DbNaceCode.Description = input.Description;

                    DbNaceCode.Code = input.Code;
                    DbNaceCode.CreatedBy = input.CreatedBy;


                    if (New == true)
                    {
                        DbNaceCode.IsDeleted = false;
                        await base.AddAsync(DbNaceCode);
                        message = "Successfully Inserted!";
                    }
                    else
                    {
                        await base.UpdateAsync(DbNaceCode);
                        message = "Successfully Updated!";
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbNaceCode.Id;

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

        public async Task<string> NaceCodeDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                NaceCode DbNaceCode = _dbContext.NaceCode.Where(u => u.Id == id).FirstOrDefault();


                if (DbNaceCode != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbNaceCode.IsDeleted = true;
                        await base.UpdateAsync(DbNaceCode);
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

        public async Task<NaceCodeModel> GetNaceCodeBYId(long id)
        {
            var result = new NaceCodeModel();
            var DbNaceCode = await Task.Run(() => _dbContext.NaceCode.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<NaceCodeModel>(DbNaceCode);
            return result;
        }

        private List<NaceCodeModel> GetPage(List<NaceCodeModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedNaceCodeModel> GetPagedNaceCodeResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedNaceCodeModel();
                var productDenoList = new List<NaceCodeModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.NaceCode.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<NaceCodeModel>>(list);
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

                result.NaceCodeModel = GetPage(productDenoList, model.Page, model.PageSize);
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
