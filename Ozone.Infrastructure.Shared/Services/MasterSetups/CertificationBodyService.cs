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
   public class CertificationBodyService : GenericRepositoryAsync<CertificationBody>, ICertificationBodyService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public CertificationBodyService(
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

        public async Task<string> Create(CertificationBodyModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                CertificationBody DbCertification = await Task.Run(() => _dbContext.CertificationBody.Where(x => x.IsDeleted == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbCertification == null)
                    {
                        New = true;
                        DbCertification = new CertificationBody();
                    }
                    //DbModules.Id = input.Id;
                    DbCertification.Id = input.Id;
                    DbCertification.Body = input.Body;
                    //DbCertification.IsActive = input.IsActive;
                    DbCertification.Description = input.Description;
                    DbCertification.Address = input.Address;
                    DbCertification.Code = input.Code;
                    DbCertification.CreatedBy = input.CreatedBy;


                    if (New == true)
                    {
                        DbCertification.IsDeleted = false;
                        await base.AddAsync(DbCertification);
                    }
                    else
                    {
                        await base.UpdateAsync(DbCertification);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbCertification.Id;

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

        public async Task<string> CertificationBodyDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                CertificationBody DbCertification = _dbContext.CertificationBody.Where(u => u.Id == id).FirstOrDefault();


                if (DbCertification != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbCertification.IsDeleted = true;
                        await base.UpdateAsync(DbCertification);
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

        public async Task<CertificationBodyModel> GetCertificationBodyBYId(long id)
        {
            var result = new CertificationBodyModel();
            var DbCertification = await Task.Run(() => _dbContext.CertificationBody.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<CertificationBodyModel>(DbCertification);
            return result;
        }

        private List<CertificationBodyModel> GetPage(List<CertificationBodyModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedCertificationBodyModel> GetPagedCertificationBodyResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedCertificationBodyModel();
                var productDenoList = new List<CertificationBodyModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.CertificationBody.Where(x => x.IsDeleted == false).ToList());
                productDenoList = _mapper.Map<List<CertificationBodyModel>>(list);
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

                result.CertificationBodyModel = GetPage(productDenoList, model.Page, model.PageSize);
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
