using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace UserManagementApp.Models
{
    public class AddMultipleClaimsForUserRequest
    {
        [Required]
        [EmailAddress]
        public string emailId { get; set; } = null!;

        public List<KeyValuePair<string, string>> claims { get; set; } = new List<KeyValuePair<string, string>>();

    }
}
