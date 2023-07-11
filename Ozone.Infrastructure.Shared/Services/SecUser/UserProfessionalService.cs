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
using Microsoft.Extensions.Configuration;

namespace Ozone.Infrastructure.Shared.Services
{
   public class UserProfessionalService : GenericRepositoryAsync<UserProfessional>, IUserProfessionalService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;


        public UserProfessionalService(
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
        public async Task<string> Create(UserProfessionalModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserProfessional DbResult = await Task.Run(() => _dbContext.UserProfessional.Where(x => x.Id == input.Id && x.IsDeleted==false).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    var message = "";
                    long newid;
                    bool New = false;
                    if (DbResult == null)
                    {
                        New = true;
                        DbResult = new UserProfessional();
                    }
                    DbResult.UserId = input.UserId;
                    DbResult.Body = input.Body;
                    DbResult.Qualification = input.Qualification;
                    DbResult.Details = input.Details;
                    DbResult.Year = input.Year;

                   
                   


                    if (New == true)
                    {
                        
                        DbResult.CreatedBy = input.CreatedBy;
                        DbResult.CreatedDate = input.CreatedDate;
                        DbResult.IsDeleted = false;
                        await base.AddAsync(DbResult);
                        message = "Successfully Inserted!";
                    }
                    else
                    {
                        DbResult.LastModifiedBy = input.LastModifiedBy;
                        DbResult.LastModifiedDate = input.LastModifiedDate;
                        await base.UpdateAsync(DbResult);
                        message = "Successfully Updated!";
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbResult.Id;
                    if (input.DocumentFile != null)
                    {
                        string filename = Path.GetFileName(input.DocumentFile.FileName);
                        string ContentType = input.DocumentFile.ContentType;

                        string reportPath = _configuration["Reporting:UserProfessionalPath"];

                        // string newFileName = @"D:\Update work\LIbrary_Documents\" + +newid + "_" + filename;

                        string newFileName = reportPath + +newid + "_" + filename;
                        // string newFileName = @"G:\OzoneDocuments\LibraryDocument\" + +newid + "_" + filename;
                        using (var stream = new FileStream(newFileName, FileMode.Create))
                        {
                            await input.DocumentFile.CopyToAsync(stream);

                        }
                        DbResult.DocumentsFilePath = newFileName;
                        DbResult.DocumentsContentType = ContentType;
                        await base.UpdateAsync(DbResult);
                        var result2 = await _unitOfWork.SaveChangesAsync();

                    }

                    transaction.Commit();
                    return message;

                }

                catch (Exception ex)
                {
                    var Exception = ex;
                    transaction.Rollback();
                    return "Not Inserted!";
                }



            }

        }

        public async Task<UserProfessionalModel> GetUserProfessionalBYId(long id)
        {
            var result = new UserProfessionalModel();
            var Dbresult = await Task.Run(() => _dbContext.UserProfessional.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<UserProfessionalModel>(Dbresult);
            return result;
        }

        private List<UserProfessionalModel> GetPage(List<UserProfessionalModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedUserProfessionalModel> GetPagedUserProfessionalResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedUserProfessionalModel();
                var UserStdList = new List<UserProfessionalModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Certification.Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();

                var list = await _dbContext.UserProfessional.Where(x => x.IsDeleted == false && x.UserId.ToString()==model.Keyword).ToListAsync();
                UserStdList = _mapper.Map<List<UserProfessionalModel>>(list);
               
                result.UserProfessionalModel = GetPage(UserStdList, model.Page, model.PageSize);
                result.TotalCount = UserStdList.Count();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> UserProfessionalDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                UserProfessional dbresult = _dbContext.UserProfessional.Where(u => u.Id == id).FirstOrDefault();


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
        public async Task<UserProfessionalModel> DownloadFile(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                UserProfessional DbLibrary = await Task.Run(() => _dbContext.UserProfessional.Where(x => x.Id == id).FirstOrDefault());

                UserProfessionalModel Li = new UserProfessionalModel();
                if (DbLibrary != null)
                {
                    Li.DocumentsFilePath = DbLibrary.DocumentsFilePath;
                    Li.DocumentsContentType = DbLibrary.DocumentsContentType;

                    //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();
                }
                return Li;
            }

        }
    }
}
