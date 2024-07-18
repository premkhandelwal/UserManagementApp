using System.ComponentModel.DataAnnotations;

namespace UserManagementApp.Models
{
    public class TokenRequest
    {
        [Required]
        public string AuthToken { get; set; } = null!;

        [Required]
        public string RefreshToken { get; set; } = null!;
    }
}
