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
   public class AccreditationService : GenericRepositoryAsync<Accreditation>, IAccreditationService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public AccreditationService(
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

        public async Task<string> Create(AccreditationModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Accreditation DbAccreditation = await Task.Run(() => _dbContext.Accreditation.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    
                    bool New = false;
                    if (DbAccreditation == null)
                    {
                        New = true;
                        DbAccreditation = new Accreditation();
                    }
                    //DbModules.Id = input.Id;
                    DbAccreditation.Id = input.Id;
                    DbAccreditation.Name = input.Name;
                    DbAccreditation.IsActive = input.IsActive;
                    DbAccreditation.Description = input.Description;

                    DbAccreditation.Code = input.Code;
                    DbAccreditation.CreatedById = input.CreatedById;


                    if (New == true)
                    {
                        DbAccreditation.IsDeleted = false;
                        await base.AddAsync(DbAccreditation);
                    }
                    else
                    {
                        await base.UpdateAsync(DbAccreditation);
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

        public async Task<string> AccreditationDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Accreditation DbAccreditation = _dbContext.Accreditation.Where(u => u.Id == id).FirstOrDefault();


                if (DbAccreditation != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbAccreditation.IsDeleted = true;
                        await base.UpdateAsync(DbAccreditation);
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

        public async Task<AccreditationModel> GetAccreditationBYId(long id)
        {
            var result = new Application.DTOs.AccreditationModel();
            var DbAccreditation = await Task.Run(() => _dbContext.Accreditation.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<AccreditationModel>(DbAccreditation);
            return result;
        }

        private List<AccreditationModel> GetPage(List<AccreditationModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedAccreditationModel> GetPagedAccreditationResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedAccreditationModel();
                var productDenoList = new List<AccreditationModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.Accreditation.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<AccreditationModel>>(list);
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

                result.AccreditationModel = GetPage(productDenoList, model.Page, model.PageSize);
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
