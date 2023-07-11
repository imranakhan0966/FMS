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

namespace Ozone.Infrastructure.Shared.Services
{
    public class SecRoleService : GenericRepositoryAsync<SecRoleForm>, ISecRoleService 
    {
        private readonly OzoneContext _context;
       
        // ISecFormRepositoryAsync _secFormRepository;
        // ISecRoleFormRepositoryAsync _secRoleFormRepository;
        //ISecRoleRepositoryAsync _secRoleRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private IUserSessionHelper _userSession;

        public SecRoleService(
        //ISecRoleFormRepositoryAsync secRoleFormRepository,
        IUnitOfWork unitOfWork,
         IUserSessionHelper userSession,
        //ISecFormRepositoryAsync secFormRepository,
       // ISecRoleRepositoryAsync secRoleRepository,
        IMapper mapper,
         OzoneContext context
            ):base(context)
        {
            //this._secRoleFormRepository = secRoleFormRepository;
           // this._secFormRepository = secFormRepository;
            this._userSession = userSession;
           // this._secRoleRepository = secRoleRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            _context = context;

        }
        //public async Task<SecRolePagedModel> GetPagedSecRoleReponse(PagedResponseModel model)
        //{
        //    try
        //    {
        //        var result = new SecRolePagedModel();
        //        var roleList = new List<SecRoleFormPagedModel>();
        //        var list = await _secRoleRepository.GetPagedSecRoleReponseAsync(model);
        //        roleList = _mapper.Map<List<SecRoleFormPagedModel>>(list);
        //        result.SecRoleFormPagedModel = GetPage(roleList, model.Page, model.PageSize);
        //        result.TotalCount = roleList.Count();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private List<SecRoleFormPagedModel> GetPage(List<SecRoleFormPagedModel> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        //public async Task<string> CreateSecRoleService(SecRoleFormPagedModel model)
        //{
        //    using (var transaction = _unitOfWork.BeginTransaction())
        //    {
        //        try
        //        {
        //            var roleForm = _mapper.Map<SecRole>(model);
        //             await _secRoleRepository.CreateSecRole(roleForm);
        //            await _unitOfWork.SaveChangesAsync();
        //            transaction.Commit();
        //            return "Successfully Created!";
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return "Not Inserted!";

        //        }
        //    }
        //}

        //public async Task<string> CreateSecRoleForm(SecRoleModelUpdate model)
        //{
        //    using (var transaction = _unitOfWork.BeginTransaction())
        //    {
        //        try
        //        {

        //            var secrole = _mapper.Map<SecRole>(model);
        //            //secrole.Name = model.RoleName;
        //            secrole.IsSubmitted = model.IsSubmitted;
        //            secrole.CreatedBy = _userSession.UserId;
        //            //secrole.Id = 0;
        //            secrole.CreatedDate = DateTime.Now;
        //            secrole.RoleType = 1;

        //            await _secRoleRepository.CreateSecRole(secrole);

        //            await _unitOfWork.SaveChangesAsync();
        //            transaction.Commit();
        //            return "Successfully Created!";
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return "Not Inserted!";

        //        }
        //    }
        //}
        //public async Task<string> Update(SecRoleModelUpdate model)
        //{
        //    using (var transaction = _unitOfWork.BeginTransaction())
        //    {
        //        try
        //        {
        //            var roleList = _secRoleRepository.Get(model.Name);
        //            var secrole = _mapper.Map<SecRole>(model);
        //            //secrole.Name = model.RoleName;
        //            secrole.IsSubmitted = true;
        //            secrole.CreatedBy = roleList.CreatedBy;
        //            secrole.CreatedDate = roleList.CreatedDate;
        //            secrole.LastModifiedBy = _userSession.UserId;
        //            secrole.LastModifiedDate = DateTime.Now;
        //            secrole.RoleType = 1;

        //            await _secRoleRepository.Update(secrole);

        //            await _unitOfWork.SaveChangesAsync();
        //            transaction.Commit();
        //            return "Successfully Updated!";
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return "Not Updated!";

        //        }
        //    }
        //}

        //public async Task<List<SecRoleFormPagedModel>> GetPagedRoleFormReponseService(QueryParameter parameter)
        //{
        //    var result = new List<SecRoleFormPagedModel>();
        //    var list = await _secRoleRepository.GetRoles();
        //    result = _mapper.Map<List<SecRoleFormPagedModel>>(list);
        //    return result;
        //}

        //public async Task<List<SecRoleFormModel>> GetSecRoleForm(QueryParameter parameter)
        //{
        //    var result = new List<SecRoleFormModel>();
        //    var list = await _secRoleFormRepository.GetAll(parameter);
        //    result = _mapper.Map<List<SecRoleFormModel>>(list);
        //    return result;
        //}
        public async Task<List<SecRoleFormPagedModel>> GetAllRoles(long id)
        {
          // long roleid= await Task.Run(() => _context.SecUser.Where(x => x.IsClosed == false && x.Id==id).Select(x=>x.RoleId).FirstOrDefault());
            int? level = await Task.Run(() => _context.SecRole.Where(x => x.IsClosed == false && x.Id == id).Select(x => x.UserLevel).FirstOrDefault());
           // await Task.Run(() => _context.SecRole.Where(x => x.IsClosed == false && x.IsAuthorized == true && x.UserLevel>level).ToList());
            var result = new List<SecRoleFormPagedModel>();
            //var list = await _secRoleRepository.GetRoles();
            //   OzoneContext _dbContext = new OzoneContext();

            if (id == 2)
            {
                var rolelist = await Task.Run(() => _context.SecRole.Where(x => x.IsClosed == false && x.IsAuthorized == true && x.UserLevel==1).ToList());
                result = _mapper.Map<List<SecRoleFormPagedModel>>(rolelist);
            }

            else
            {
                var list = await Task.Run(() => _context.SecRole.Where(x => x.IsClosed == false && x.IsAuthorized == true && x.UserLevel > level).ToList());
                result = _mapper.Map<List<SecRoleFormPagedModel>>(list);

            }
            return result;
        }
        public async Task<List<SecUserTypeModel>> GetAllUserType(long id)
        {
          var level = await Task.Run(() => _context.UserType.Where(x => x.IsActive == true && x.Id==id ).FirstOrDefaultAsync());
           
            // OzoneContext _dbContext = new OzoneContext();
            List<SecUserTypeModel> result = new List<SecUserTypeModel>();
            var list = await Task.Run(() => _context.UserType.Where(x => x.IsActive == true && x.UserLevel>=level.UserLevel).ToList());
            foreach (var UsertypeMod in list)
            {
                SecUserTypeModel usertype = new SecUserTypeModel();
                usertype.Id = UsertypeMod.Id;
                usertype.Name = UsertypeMod.Name;
                usertype.UserLevel = UsertypeMod.UserLevel;

                result.Add(usertype);


            }
           
           // result = _mapper.Map<List<SecUserTypeModel>>(list);
            return result;
        }


        //public async Task<List<SecRoleModelUpdate>> GetAllSecRoleForm()
        //{
        //    try { 
        //    var result = new List<SecRoleModelUpdate>();
        //    var list = await _secRoleFormRepository.GetSecRoleForm();
        //    result = _mapper.Map<List<SecRoleModelUpdate>>(list);
        //    return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        //public async Task<List<SecFormPagedModel>> GetPagedSecFormReponseService(QueryParameter parameter)
        //{
        //    var result = new List<SecFormPagedModel>();
        //    var list = await _secFormRepository.GetAllPermissions(parameter);
        //    result = _mapper.Map<List<SecFormPagedModel>>(list);
        //    return result;
        //}

        public async Task<List<SecRoleFormLoginModel>> GetAllRoleFormByRoleId(long id)
        {
           
                //  OzoneContext dbContext = new OzoneContext();
                var result = new List<SecRoleFormLoginModel>();
            try
            {
                var ListRoleform = _context.SecRoleForm.Include("SecForm").Where(x => x.RoleId == id && (x.UpdateAllowed == true || x.InsertAllowed == true || x.AuthAllowed == true || x.QueryAllowed == true || x.DeleteAllowed == true || x.ViewRecordAllowed == true)).ToListAsync();
                var forms = (await Task.Run(() => _context.SecForm.ToList()));

                var list = (await Task.Run(() => _context.SecRoleForm.Where(x => x.RoleId == id).ToList()));
                List<SecRoleFormLoginModel> secRoleFormLoginmodel = new List<SecRoleFormLoginModel>();
                foreach (var listroleForm in list)
                {
                    SecRoleFormLoginModel mod = new SecRoleFormLoginModel();
                    mod.Id = listroleForm.Id;
                    mod.FormId = listroleForm.PermissionId;
                    mod.RoleId = listroleForm.RoleId;
                    mod.FormCode = forms.Where(a => a.Id == mod.FormId).Select(a => a.Code).FirstOrDefault();

                    mod.FormName = forms.Where(a => a.Id == mod.FormId).Select(a => a.Name).FirstOrDefault();
                    mod.InsertAllowed = listroleForm.InsertAllowed;
                    mod.UpdateAllowed = listroleForm.UpdateAllowed;
                    // mod.
                    mod.QueryAllowed = listroleForm.QueryAllowed;
                   // mod.SbpAllowed = listroleForm.SbpAllowed.Value;

                    mod.AuthAllowed = listroleForm.AuthAllowed;

                    mod.ManageAllowed = listroleForm.ManageAllowed;

                    mod.DeleteAllowed = listroleForm.DeleteAllowed;
                    mod.ViewRecordAllowed = listroleForm.ViewRecordAllowed;
                    secRoleFormLoginmodel.Add(mod);

                }


                //   var list = await _secRoleFormRepository.GetAllByRoleId(id);
                // result = _mapper.Map<List<SecRoleFormLoginModel>>(list);
                return secRoleFormLoginmodel;
            }
            catch (Exception ex) 
            {
                return result;
            }
         }
        public async Task<List<CityModel>> GetAllCities()
        {
            var result = new List<CityModel>();
            //var list = await _secRoleRepository.GetRoles();
            //   OzoneContext _dbContext = new OzoneContext();
            var list = await Task.Run(() => _context.Cities.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<CityModel>>(list);
            return result;
        }
        public async Task<List<CountryModel>> GetAllCountry()
        {
            var result = new List<CountryModel>();
            //var list = await _secRoleRepository.GetRoles();
            //   OzoneContext _dbContext = new OzoneContext();
            var list = await Task.Run(() => _context.Countries.Where(x=>x.IsActive==true).ToList());
            result = _mapper.Map<List<CountryModel>>(list);
            return result;
        }


        public async Task<List<PrefixModel>> GetAllPrefix()
        {
            var result = new List<PrefixModel>();
            //var list = await _secRoleRepository.GetRoles();
            //   OzoneContext _dbContext = new OzoneContext();
            var list = await Task.Run(() => _context.Prifix.Where(x=>x.IsActive==true).ToList());
            result = _mapper.Map<List<PrefixModel>>(list);
            return result;
        }
        public async Task<List<StateModel>> GetAllState()
        {
            var result = new List<StateModel>();
            //var list = await _secRoleRepository.GetRoles();
            //   OzoneContext _dbContext = new OzoneContext();
            var list = await Task.Run(() => _context.State.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<StateModel>>(list);
            return result;
        }
        public async Task<List<IsActiveModel>> GetAllActiveStatus()
        {
            var result = new List<IsActiveModel>();
            //var list = await _secRoleRepository.GetRoles();
            //   OzoneContext _dbContext = new OzoneContext();
            var list = await Task.Run(() => _context.Active.ToList());
            result = _mapper.Map<List<IsActiveModel>>(list);
            return result;
        }
        public Task<SecRolePagedModel> GetPagedSecRoleReponse(PagedResponseModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateSecRoleService(SecRoleFormPagedModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateSecRoleForm(SecRoleModelUpdate model)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(SecRoleModelUpdate model)
        {
            throw new NotImplementedException();
        }

        public Task<List<SecRoleFormPagedModel>> GetPagedRoleFormReponseService(QueryParameter parameter)
        {
            throw new NotImplementedException();
        }

        //public Task<List<SecRoleFormPagedModel>> GetAllRoles()
        //{
        //    throw new NotImplementedException();
        //}

        public Task<List<SecFormPagedModel>> GetPagedSecFormReponseService(QueryParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<List<SecRoleFormModel>> GetSecRoleForm(QueryParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<SecRoleModelUpdate> GetAllPermissionsByRoleId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SecRoleModelUpdate>> GetAllSecRoleForm()
        {
            throw new NotImplementedException();
        }

        public Task AuthorizeRole(long id, string Remarks)
        {
            throw new NotImplementedException();
        }

        public Task RejectRole(long id, string Remarks)
        {
            throw new NotImplementedException();
        }

        //public async Task<SecRoleModelUpdate> GetAllPermissionsByRoleId(long id)
        //{
        //    try
        //    {
        //    var result = new SecRoleModelUpdate();
        //    var roleList =  await _secRoleRepository.GetRolesById(id);
        //    //var list = await _secRoleFormRepository.GetAllPermissions(id);
        //    result = _mapper.Map<SecRoleModelUpdate>(roleList);
        //    return result;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        //public async Task AuthorizeRole(long id, string Remarks)
        //{
        //    using (var transaction = _unitOfWork.BeginTransaction())
        //    {
        //        try
        //        {
        //            await _secRoleRepository.Authorize(id, Remarks);
        //            await _unitOfWork.SaveChangesCheckerApprovalAsync();
        //            transaction.Commit();
        //            return;
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return;

        //        }
        //    }
        //}
        //public async Task RejectRole(long id, string Remarks)
        //{
        //    using (var transaction = _unitOfWork.BeginTransaction())
        //    {
        //        try
        //        {
        //            await _secRoleRepository.Reject(id, Remarks);
        //            await _unitOfWork.SaveChangesCheckerApprovalAsync();
        //            transaction.Commit();
        //            return;
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return;

        //        }
        //    }
        //}
    }
}
