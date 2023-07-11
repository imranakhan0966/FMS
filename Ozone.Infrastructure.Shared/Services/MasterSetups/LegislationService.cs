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

namespace Ozone.Infrastructure.Shared.Services.MasterSetups
{
   public class LegislationService : GenericRepositoryAsync<Legislation>, ILegislationService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public LegislationService(
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

        public async Task<string> Create(LegislationModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Legislation DbLegislation = await Task.Run(() => _dbContext.Legislation.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbLegislation == null)
                    {
                        New = true;
                        DbLegislation = new Legislation();
                    }
                    //DbModules.Id = input.Id;
                    DbLegislation.Id = input.Id;
                    DbLegislation.Name = input.Name;
                    DbLegislation.IsActive = input.IsActive;
                    DbLegislation.Description = input.Description;

                    DbLegislation.Code = input.Code;
                    //DbLegislation.CreatedBy = input.CreatedBy;


                    if (New == true)
                    {
                        DbLegislation.IsDeleted = false;
                        await base.AddAsync(DbLegislation);

                     
                    }
                    else
                    {
                        await base.UpdateAsync(DbLegislation);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbLegislation.Id;

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

        public async Task<string> LegislationDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Legislation DbLegislation = _dbContext.Legislation.Where(u => u.Id == id).FirstOrDefault();


                if (DbLegislation != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbLegislation.IsDeleted = true;
                        await base.UpdateAsync(DbLegislation);
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

        public async Task<LegislationModel> GetLegislationBYId(long id)
        {
            var result = new LegislationModel();
            var DbLegislation = await Task.Run(() => _dbContext.Legislation.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<LegislationModel>(DbLegislation);
            return result;
        }

        private List<LegislationModel> GetPage(List<LegislationModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedLegislationModel> GetPagedLegislationResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedLegislationModel();
                var productDenoList = new List<LegislationModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.Legislation.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<LegislationModel>>(list);
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

                result.LegislationModel = GetPage(productDenoList, model.Page, model.PageSize);
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
