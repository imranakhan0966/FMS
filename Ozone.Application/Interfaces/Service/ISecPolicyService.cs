using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Service
{
    public interface ISecPolicyService
    {
        Task<List<SecPolicyModel>> GetAllActiveSecPolicy();
        Task<SecPolicyModel> GetDuplicateLoginAllowedPolicy();
        Task<SecPolicyModel> GetLockingIncorrectAttemptsPolicy();
        Task<SecPolicyModel> GetUnlockTimeMinutesPolicy();
        Task<SecPolicyModel> GetReusingSamePasswordPolicy();
        Task<SecPolicyModel> GetPasswordComplexityRegexPolicy();
    }
}
