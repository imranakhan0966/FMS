using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using AutoMapper;
using Ozone.Application;
using Ozone.Application.Interfaces;
using System.Linq;

namespace Ozone.Infrastructure.Shared.Services
{
    public class StandardService : GenericRepositoryAsync<Certification>, IStandardService
    {

        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public StandardService(
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
        public async Task<string> Create(CertificationModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
            Certification DbCertification = await Task.Run(() => _dbContext.Certification.Where(x => x.IsActive == true && x.Id==input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                    {
                    var message = "";
                        long newid;
                        bool New = false;
                        if (DbCertification == null)
                        {
                            New = true;
                            DbCertification = new Certification();
                        }
                        DbCertification.Code = input.Code;
                        DbCertification.Name = input.Name;
                        DbCertification.Description = input.Description;
                        DbCertification.StartDate = input.StartDate;
                        DbCertification.IsActive = true;
                        DbCertification.IsDeleted = false;

                        if (New == true)
                        {
                            await base.AddAsync(DbCertification);
                        message = "Successfully Inserted!";
                        }
                        else
                        {
                            await base.UpdateAsync(DbCertification);
                        message = "Successfully Updated!";
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
                        return message;

                    }

                    catch
                    {
                        transaction.Rollback();
                        return "Not Inserted!";
                    }



                }
            
        }

        public async Task<CertificationModel> GetStandardBYId(long id)
        {
            var result = new CertificationModel();
            var DbCertification = await Task.Run(() => _dbContext.Certification.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<CertificationModel>(DbCertification);
            return result;
        }

        private List<CertificationModel> GetPage(List<CertificationModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedStandardModel> GetPagedStandardResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedStandardModel();
                var productDenoList = new List<CertificationModel>();

                //if (model.AuthAllowed == true)
                //{
                    //var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true &&
                    //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                    //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();

                    var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true).ToListAsync();
                    productDenoList = _mapper.Map<List<CertificationModel>>(list);
                    // return list;
                //}


                //else
                //{
                //    var list = await _dbContext.Certification.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //                 (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //                x.Code.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //    productDenoList = _mapper.Map<List<StandardModel>>(list);
                //    // return list;
                //}
                //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

                result.StandardModel = GetPage(productDenoList, model.Page, model.PageSize);
                result.TotalCount = productDenoList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> StandardDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Certification dbresult = _dbContext.Certification.Where(u => u.Id == id).FirstOrDefault();


                if (dbresult != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        dbresult.IsDeleted = true;
                        await base.UpdateAsync(dbresult);
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
        //public async Task<List<StandardModel>> GetAllModule()
        //{
        //    var result = new List<StandardModel>();

        //    var list = await Task.Run(() => _dbContext.Module.Where(x => x.IsActive == true).ToList());
        //    result = _mapper.Map<List<StandardModel>>(list);
        //    return result;
        //}
    } }