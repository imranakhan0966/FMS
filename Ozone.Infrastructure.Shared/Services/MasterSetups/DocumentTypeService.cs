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
    public class DocumentTypeService : GenericRepositoryAsync<DocumentType>, IDocumentTypeService
    {
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;
        private IUserSessionHelper _userSession;
        // private IDataShapeHelper<Library> _dataShaper;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentTypeService(
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

        public async Task<string> Create(DocumentsTypeModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                DocumentType DbDocument = await Task.Run(() => _dbContext.DocumentType.Where(x => x.IsDeleteed == false && x.Id == input.Id).FirstOrDefault());

                //string password = _secPolicyRepo.GetPasswordComplexityRegexPolicy().ToString();


                try
                {
                    long newid;
                    bool New = false;
                    if (DbDocument == null)
                    {
                        New = true;
                        DbDocument = new DocumentType();
                    }
                    //DbModules.Id = input.Id;
                    DbDocument.Id = input.Id;
                    DbDocument.Name = input.Name;
                    DbDocument.IsActive = input.IsActive;
                    DbDocument.Description = input.Description;

                    DbDocument.Code = input.Code;


                    if (New == true)
                    {
                        DbDocument.IsDeleteed = false;
                        await base.AddAsync(DbDocument);
                    }
                    else
                    {
                        await base.UpdateAsync(DbDocument);
                    }
                    //await base.AddAsync(secuserEntity);
                    //await SecUser.(secuserEntity);
                    // _dbContext.SecUser.Add(secuserEntity);
                    //  ozonedb.Add
                    //  await _secuserRepository.CreateUser(secuserEntity);
                    // await _unitOfWork.SaveChangesAsync();
                    var result = await _unitOfWork.SaveChangesAsync();

                    newid = DbDocument.Id;

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

        public async Task<string> DocumentTypeDeleteById(long id)
        {
            // OzoneContext ozonedb = new OzoneContext();
            using (var transaction = _unitOfWork.BeginTransaction())
            {


                DocumentType DbDocument = _dbContext.DocumentType.Where(u => u.Id == id).FirstOrDefault();


                if (DbDocument != null)
                {
                    // SecUser user = _secuserRepository.GetUserByUserName(input.UserName);

                    try
                    {


                        DbDocument.IsDeleteed = true;
                        await base.UpdateAsync(DbDocument);
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

        public async Task<DocumentsTypeModel> GetDocumentsTypeBYId(long id)
        {
            var result = new DocumentsTypeModel();
            var DbDocument = await Task.Run(() => _dbContext.DocumentType.Where(x => x.Id == id).FirstOrDefault());
            result = _mapper.Map<DocumentsTypeModel>(DbDocument);
            return result;
        }

        private List<DocumentsTypeModel> GetPage(List<DocumentsTypeModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<GetPagedDocumentsTypeModel> GetPagedDocumentsTypeResponse(PagedResponseModel model)
        {
            try
            {

                var result = new GetPagedDocumentsTypeModel();
                var productDenoList = new List<DocumentsTypeModel>();

                //if (model.AuthAllowed == true)
                //{
                //var list = await _dbContext.Module.Include("Module").Include("Status").Where(x => x.IsDeleted == false && x.IsActive == true &&
                //              (x.Module.Name.ToLower().Contains(model.Keyword.ToLower()) ||
                //             x.ModuleId.ToString().ToLower().Contains(model.Keyword.ToLower()))).OrderByDescending(x => x.Id).ToListAsync();
                //productDenoList = _mapper.Map<List<ModulesModel>>(list);
                // return list;

                var list = await Task.Run(() => _dbContext.DocumentType.Where(x => x.IsDeleteed == false).ToList());
                productDenoList = _mapper.Map<List<DocumentsTypeModel>>(list);
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

                result.DocumentsTypeModel = GetPage(productDenoList, model.Page, model.PageSize);
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
