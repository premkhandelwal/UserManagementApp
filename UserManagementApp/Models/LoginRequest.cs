using System.ComponentModel.DataAnnotations;

namespace UserManagementApp.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string emailId {  get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;
    }
}
