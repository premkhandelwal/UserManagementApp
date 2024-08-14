using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Models.UserManagementRequests
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string emailId { get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;
    }
}
