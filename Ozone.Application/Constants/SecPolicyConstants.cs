using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Constants
{
    public class SecPolicyConstants
    {
        public const string DuplicateLoginAllowed = "DUPLICATE_LOGIN_ALLOWED";
        public const string LockingIncorrectAttempts = "LOCKING_INCORRECT_ATTEMPTS";
        public const string UnlockTimeMinutes = "UNLOCK_TIME_MINUTES";
        public const string ReusingSamePassword = "REUSING_SAME_PASSWORD";
        public const string PasswordComplexityRegex = "PASSWORD_COMPLEXITY_REGEX";
    }
}
