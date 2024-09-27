using Crm.Admin.Service.Models;

namespace CRM.Admin.Service.Models
{
    public class TokenRefreshResponse
    {
        public bool IsSuccess { get; set; }
        public TokenRefreshStatus Status { get; set; } // Use the enum for status
        public string? Message { get; set; }
        public string? UserId { get; set; }
        public string? AuthToken { get; set; }
        public string? RefreshToken { get; set; }
    }

}
