using System.ComponentModel.DataAnnotations;

namespace CRM.Api.Models.UserManagementRequests
{
    public class AssignRoleRequest
    {
        [Required]
        public string role { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string emailId { get; set; } = null!;
    }
}
