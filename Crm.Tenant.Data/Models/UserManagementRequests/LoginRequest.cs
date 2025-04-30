using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Models.UserManagementRequests
{
    public class LoginRequest
    {
        [Required]
        public string userName { get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;
    }
}
