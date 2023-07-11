using AutoMapper;
using Ozone.Application;
using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Security;


//using Ozone.Domain.Entities;
using Ozone.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozone.Infrastructure.Persistence.Models;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Parameters;
using Ozone.Application.Interfaces;
//using Ozone.Infrastructure.Persistence.Repository;
using Ozone.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Ozone.Application.Repository;
using System.IO;
using Microsoft.Extensions.Configuration;
//using AutoMapper.Configuration;

namespace Ozone.Infrastructure.Shared.Services
{
    public class LibraryResources : GenericRepositoryAsync<Library>, ILibraryResources
    {

        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;
        public LibraryResources(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        IUserSessionHelper userSession, IConfiguration configuration) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._userSession = userSession;
            //_mockData = mockData;
            this._configuration = configuration;
        }


        public async Task<List<ModuleModel>> GetAllModule()
        {
            var result = new List<ModuleModel>();



            var list = await Task.Run(() => _dbContext.Module.Where(x => x.IsActive == true && x.IsDeleted==false).ToList());
            result = _mapper.Map<List<ModuleModel>>(list);
            ModuleModel MM = new ModuleModel();
            MM.Id = 0;
            MM.Name = "--- All ---";
            result.Add(MM);
            return result.OrderBy(x=>x.Id).ToList();
        }
        public async Task<List<DocumentsTypeModel>> GetDocumentsType()
        {
            var result = new List<DocumentsTypeModel>();

            var list = await Task.Run(() => _dbContext.DocumentType.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<DocumentsTypeModel>>(list);
            return result;
        }
        public async Task<List<SecUserModel>> GetAllReviewer(long orgId)
        {
            var result = new List<SecUserModel>();

            var list = await Task.Run(() => _dbContext.SecUser.Where(x => x.IsActive == true && x.IsDeleted==false && x.OrganizationId==orgId).ToList());
            result = _mapper.Map<List<SecUserModel>>(list);
            return result;
        }
        public async Task<List<StatusModel>> GetAllStatus()
        {
            var result = new List<StatusModel>();

            var list = await Task.Run(() => _dbContext.Status.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<StatusModel>>(list);
            return result;
        }

        public async Task<List<CertificationModel>> GetAllCertification()
        {
            var result = new List<CertificationModel>();

            var list = await Task.Run(() => _dbContext.Certification.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<CertificationModel>>(list);
            return result.OrderByDescending(x=>x.Id).ToList();
        }


        public async Task<string> CreateLibrary(LibraryResourcesModel input)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Library DbLibrary = await Task.Run(() => _dbContext.Library.Where(x => x.Id == input.Id).FirstOrDefault());


                if (input.File != null || DbLibrary.FilePath !=null)
                {
                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                    try
                    {
                        long newid;
                        bool New = false;
                        if (DbLibrary == null)
                        {
                            New = true;
                            DbLibrary = new Library();
                        }
                           
                            DbLibrary.ModuleId = input.ModuleId;
                            DbLibrary.Title = input.Title;
                            DbLibrary.Version = input.Version;
                            DbLibrary.Date = input.Date;
                            DbLibrary.Description = input.Description;
                            DbLibrary.Reviewer = input.Reviewer;
                            DbLibrary.IsActive = true;
                            DbLibrary.IsDeleted = false;
                            DbLibrary.DocumentTypeId = input.DocumentTypeId;
                            DbLibrary.CertificationId = input.CertificationId;


                            DbLibrary.StatusId = input.StatusId;
                            DbLibrary.IsSubmitted = input.IsSubmitted;
                        if (New == true)
                        {
                            await base.AddAsync(DbLibrary);
                        }
                        else {
                            await base.UpdateAsync(DbLibrary);
                                }
                            //await base.AddAsync(secuserEntity);
                            //await SecUser.(secuserEntity);
                            // _dbContext.SecUser.Add(secuserEntity);
                            //  ozonedb.Add
                            //  await _secuserRepository.CreateUser(secuserEntity);
                            // await _unitOfWork.SaveChangesAsync();
                            var result = await _unitOfWork.SaveChangesAsync();

                             newid = DbLibrary.Id;

                            transaction.Commit();
                        if (input.File != null)
                        {
                            string filename = Path.GetFileName(input.File.FileName);
                            string ContentType = input.File.ContentType;

                            string reportPath = _configuration["Reporting:LibraryDocumentsPath"];

                            // string newFileName = @"D:\Update work\LIbrary_Documents\" + +newid + "_" + filename;

                            string newFileName = reportPath + +newid + "_" + filename;
                            // string newFileName = @"G:\OzoneDocuments\LibraryDocument\" + +newid + "_" + filename;
                            using (var stream = new FileStream(newFileName, FileMode.Create))
                            {
                                await input.File.CopyToAsync(stream);

                            }
                            DbLibrary.FilePath = newFileName;
                            DbLibrary.ContentType = ContentType;
                            await base.UpdateAsync(DbLibrary);
                            var result2 = await _unitOfWork.SaveChangesAsync();
                        }
                            return "Successfully Inserted!";
                        
                       

                    }
                    catch (Exception ex)
                    {
                        var Exception = ex;
                        transaction.Rollback();
                        return "Not Inserted!";
                    }



                }
                else
                {
                    return "Please Select Document !";
                }
                //return "User Already Exists!";
            }

        }
        //Task<LibraryResourcesModel> GetLibraryBYId();
        public async Task<LibraryResourcesModel> GetLibraryBYId(long id)
        {
            var result = new LibraryResourcesModel();
        var DbLibrary = await Task.Run(() => _dbContext.Library.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<LibraryResourcesModel>(DbLibrary);
            return result;
        }
        public async Task<string> CreateLibraryNew(LibraryModelForCreate input)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Library DbLibrary = await Task.Run(() => _dbContext.Library.FirstOrDefault());


                if (DbLibrary == null)
                {
                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                    try
                    {
                        if (input.File != null)
                        {
                            Library secuserEntity = new Library();
                            //secuserEntity.ModuleId = input.ModuleId;
                            //secuserEntity.Title = input.Title;
                            //secuserEntity.Version = input.Version;
                            //secuserEntity.Date = input.Date;
                            //secuserEntity.Description = input.Description;
                            //secuserEntity.Reviewer = input.Reviewer;
                            //secuserEntity.IsActive = true;
                            //secuserEntity.IsDeleted = false;
                            //secuserEntity.DocumentTypeId = input.DocumentTypeId;

                            //secuserEntity.StatusId = input.StatusId;
                            //secuserEntity.IsSubmitted = input.IsSubmitted;

                            await base.AddAsync(secuserEntity);
                            //await base.AddAsync(secuserEntity);
                            //await SecUser.(secuserEntity);
                            // _dbContext.SecUser.Add(secuserEntity);
                            //  ozonedb.Add
                            //  await _secuserRepository.CreateUser(secuserEntity);
                            // await _unitOfWork.SaveChangesAsync();
                            var result = await _unitOfWork.SaveChangesAsync();

                            long id = secuserEntity.Id;

                            transaction.Commit();


                            string filename = Path.GetFileName(input.File.FileName);
                            string ContentType = Path.GetFileName(input.File.ContentType);

                            string newFileName = @"D:\Update work\LIbrary_Documents\" + +id + "_" + filename;

                            using (var stream = new FileStream(newFileName, FileMode.Create))
                            {
                                await input.File.CopyToAsync(stream);

                            }
                            return "Successfully Inserted!";
                        }
                        else
                        {
                            return "File Can not be Empty!";
                        }

                    }
                    catch (Exception ex)
                    {
                        var Exception = ex;
                        transaction.Rollback();
                        return "Not Inserted!";
                    }



                }
                else
                {
                    return "User Already Exists!";
                }
                //return "User Already Exists!";
            }

        }
        public async Task<LibraryResourcesModel> DownloadLibrary(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Library DbLibrary = await Task.Run(() => _dbContext.Library.Where(x => x.Id == id).FirstOrDefault());

                LibraryResourcesModel Li = new LibraryResourcesModel();
                if (DbLibrary != null)
                {
                    Li.FilePath = DbLibrary.FilePath;
                    Li.ContentType = DbLibrary.ContentType;

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                }
                return Li;
            }

        }

        //Task<List<LibraryResourcesModel>> ILibraryResources.GetAllModule()
        //{
        //    throw new NotImplementedException();
        //}



        //Task<List<LibraryResourcesModel>> ILibraryResources.GetAllModule()
        //{
        //    throw new NotImplementedException();
        //}
        private List<LibraryResourcesModel> GetPage(List<LibraryResourcesModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedLibraryModel> GetPagedLibraryResourcesResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedLibraryModel();
                var productDenoList = new List<LibraryResourcesModel>();

                if (model.AuthAllowed == true)
                {
                    var list = await _dbContext.Library.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true  &&
                                  (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                                 x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                    productDenoList = _mapper.Map<List<LibraryResourcesModel>>(list);
                    // return list;
                }


                else
                {
                    var list = await _dbContext.Library.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                                 (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                                x.Code.ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                    productDenoList = _mapper.Map<List<LibraryResourcesModel>>(list);
                    // return list;
                }
                //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

                result.LibraryModel = GetPage(productDenoList, model.Page, model.PageSize);
                result.TotalCount = productDenoList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> LibraryDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                Library dbresult = _dbContext.Library.Where(u => u.Id == id).FirstOrDefault();


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
                        var Exception = ex;
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

        public async Task<GetPagedLibraryModel> GetDocumentsByStandardId(long StandardId, PagedResponseModel model)
        {
            var result = new GetPagedLibraryModel();
            try
            {

                //var result = new GetPagedLibraryModel();
                var productDenoList = new List<LibraryResourcesModel>();

              
                    var list = await _dbContext.Library.Where(x => x.IsDeleted == false && x.IsActive == true && x.CertificationId== StandardId).ToListAsync();
                    productDenoList = _mapper.Map<List<LibraryResourcesModel>>(list);

                //  var list = await _productDenominationRepository.GetPagedProductDenominationReponseAsync(model);

                //result.LibraryModel = GetPage(productDenoList, model.Page, model.PageSize);
                result.LibraryModel = productDenoList;
                result.TotalCount = productDenoList.Count();
                return result;
            }
            catch (Exception ex)
            {
                var exp = ex;
                return result;
                //throw ex;
            }
        }

        public async Task<List<CertificationModel>> GetAllStandard()
        {
            var result = new List<CertificationModel>();

            CertificationModel MM = new CertificationModel();
            MM.Id = 0;
            MM.Name = "Not Selected";

            var list = await Task.Run(() => _dbContext.Certification.Where(x => x.IsActive == true && x.IsDeleted == false).ToList());
            result = _mapper.Map<List<CertificationModel>>(list);
            result.Add(MM);
            return result.OrderBy(x => x.Id).ToList();
        }
        public async Task<GetPagedLibraryModel> GetAlldata(Dictionary<string, string> keyValuePairs,int model)
        {
            var result = new List<LibraryResourcesModel>();
            var list = await Task.Run(() => _dbContext.Library.Include(x => x.Module).Include(x => x.Certification).Where(x => x.IsActive == true && x.IsDeleted == false).ToList());
            result = _mapper.Map<List<LibraryResourcesModel>>(list);
            foreach (var property in keyValuePairs)
            {
                var searchValue = property.Value.ToLower();
                var pr = property.Key.ToLower();
                switch (property.Key.ToLower())
                {

                    case "certificationid":
                        if (searchValue != "" && searchValue != null && Convert.ToInt64(searchValue)>0)
                        {
                            
                            result = result.Where(x =>  x.CertificationId  == Convert.ToInt64(searchValue)).ToList();
                        }
                        break;
                    case "moduleid":
                        if (searchValue != "" && searchValue != null && Convert.ToInt64(searchValue) > 0)
                        {
                            result = result.Where(x => x.ModuleId == Convert.ToInt64(searchValue)).ToList();
                        }
                        break;
                    case "title":
                        if (searchValue != "" && searchValue != null)
                        {
                            result = result.Where(x => x.Title.ToLower().Contains(Convert.ToString(searchValue))).ToList();
                        }
                        break;



                }
            }

            var resultlibrary = new GetPagedLibraryModel();
           // var libraryList = new List<LibraryResourcesModel>();

            //var farooq  = await _dbContext.UserStandards.Include(x => x.Standard).Include(x => x.AuditorType).Include(x => x.CourseType).Include(x => x.User).Where(x => x.IsDeleted == false && x.UserId.ToString() == model.Keyword).ToListAsync();
            //libraryList = _mapper.Map<List<LibraryResourcesModel>>(list);
            resultlibrary.LibraryModel = GetPage(result, model, 10);
            resultlibrary.TotalCount = result.Count();
            return resultlibrary;


        }
    }
}
