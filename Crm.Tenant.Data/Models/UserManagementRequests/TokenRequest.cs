using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Models.UserManagementRequests
{
    public class TokenRequest
    {
        [Required]
        public string AuthToken { get; set; } = null!;

        [Required]
        public string RefreshToken { get; set; } = null!;
    }
}
