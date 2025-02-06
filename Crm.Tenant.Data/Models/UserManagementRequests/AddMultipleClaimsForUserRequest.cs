using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Crm.Api.Models.UserManagementRequests
{
    public class AddMultipleClaimsForUserRequest
    {
        [Required]
        public string username { get; set; } = null!;

        public List<KeyValuePair<string, string>> claims { get; set; } = new List<KeyValuePair<string, string>>();

    }
}
