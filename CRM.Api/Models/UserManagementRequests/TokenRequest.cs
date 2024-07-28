using System.ComponentModel.DataAnnotations;

namespace CRM.Api.Models.UserManagementRequests
{
    public class TokenRequest
    {
        [Required]
        public string AuthToken { get; set; } = null!;

        [Required]
        public string RefreshToken { get; set; } = null!;
    }
}
