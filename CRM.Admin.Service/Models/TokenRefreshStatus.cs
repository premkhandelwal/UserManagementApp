using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Admin.Service.Models
{
    public enum TokenRefreshStatus
    {
        Success = 0,
        TokenExpired = 500,
        InvalidTokenAlgorithm = 501,
        TokenExpiryTimeNotFound = 502,
        TokenNotYetExpired = 503,
        TokenDoesNotExist = 504,
        TokenHasBeenUsed = 505,
        TokenHasBeenRevoked = 506,
        TokenDoesNotMatch = 507,
        GeneralError = 508
    }

}
