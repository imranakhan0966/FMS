using AutoMapper;
using Ozone.Application.Constants;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
//using Ozone.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
    public class SecPolicyService :GenericRepositoryAsync<SecRoleForm> , ISecPolicyService
    {
        private readonly OzoneContext _dbContext;
        //ISecPolicyRepositoryAsync _secPolicyRepo;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfwork;
        private List<SecPolicy> _secPolicyList;

        public SecPolicyService(/*ISecPolicyRepositoryAsync secPolicyRepo,*/ IMapper mapper, IUnitOfWork unitOfWork ,OzoneContext context) : base(context)
        {
            _dbContext = context;
           // this._secPolicyRepo = secPolicyRepo;
            this._mapper = mapper;
            this._unitOfwork = unitOfWork;
        }


        public async Task<List<SecPolicyModel>> GetAllActiveSecPolicy()
        {
            OzoneContext ozonedb = new OzoneContext();
            _secPolicyList =await Task.Run(()=> ozonedb.SecPolicy.Where(sp => sp.IsClosed == false && sp.IsSubmitted == true && sp.IsAuthorized == true).ToList());
            //_secPolicyList = await _secPolicyRepo.GetAllActiveSecPolicy();
            return _mapper.Map<List<SecPolicyModel>>(_secPolicyList);
        }

        public async Task<SecPolicyModel> GetDuplicateLoginAllowedPolicy()
        {
            if (_secPolicyList == null)
                await GetAllActiveSecPolicy();
            SecPolicy sPolicy = _secPolicyList.Where(sp => sp.Name == SecPolicyConstants.DuplicateLoginAllowed).FirstOrDefault();

            return _mapper.Map<SecPolicyModel>(sPolicy);
        }

        public async Task<SecPolicyModel> GetLockingIncorrectAttemptsPolicy()
        {
            if (_secPolicyList == null)
                await GetAllActiveSecPolicy();
            SecPolicy sPolicy = _secPolicyList.Where(sp => sp.Name == SecPolicyConstants.LockingIncorrectAttempts).FirstOrDefault();

            return _mapper.Map<SecPolicyModel>(sPolicy);
        }

        public async Task<SecPolicyModel> GetUnlockTimeMinutesPolicy()
        {
            if (_secPolicyList == null)
                await GetAllActiveSecPolicy();
            SecPolicy sPolicy = _secPolicyList.Where(sp => sp.Name == SecPolicyConstants.UnlockTimeMinutes).FirstOrDefault();

            return _mapper.Map<SecPolicyModel>(sPolicy);
        }

        public async Task<SecPolicyModel> GetReusingSamePasswordPolicy()
        {
            if (_secPolicyList == null)
                await GetAllActiveSecPolicy();
            SecPolicy sPolicy = _secPolicyList.Where(sp => sp.Name == SecPolicyConstants.ReusingSamePassword).FirstOrDefault();

            return _mapper.Map<SecPolicyModel>(sPolicy);
        }

        public async Task<SecPolicyModel> GetPasswordComplexityRegexPolicy()
        {
            if (_secPolicyList == null)
                await GetAllActiveSecPolicy();
            SecPolicy sPolicy = _secPolicyList.Where(sp => sp.Name == SecPolicyConstants.PasswordComplexityRegex).FirstOrDefault();

            return _mapper.Map<SecPolicyModel>(sPolicy);
        }

        Task<List<SecPolicyModel>> ISecPolicyService.GetAllActiveSecPolicy()
        {
            throw new NotImplementedException();
        }

        Task<SecPolicyModel> ISecPolicyService.GetDuplicateLoginAllowedPolicy()
        {
            throw new NotImplementedException();
        }

        Task<SecPolicyModel> ISecPolicyService.GetLockingIncorrectAttemptsPolicy()
        {
            throw new NotImplementedException();
        }

        Task<SecPolicyModel> ISecPolicyService.GetUnlockTimeMinutesPolicy()
        {
            throw new NotImplementedException();
        }

        Task<SecPolicyModel> ISecPolicyService.GetReusingSamePasswordPolicy()
        {
            throw new NotImplementedException();
        }

        Task<SecPolicyModel> ISecPolicyService.GetPasswordComplexityRegexPolicy()
        {
            throw new NotImplementedException();
        }
    }
}
