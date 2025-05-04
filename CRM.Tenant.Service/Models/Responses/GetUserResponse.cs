using Crm.Tenant.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRM.Tenant.Service.Models.Responses
{
    public class GetUserResponse
    {
        public int? Id { get; set; }
        public string? UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Password { get; set; }
        public string Role { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public DateTime? LastLogin { get; set; }

        public List<string> UserPermissions { get; set; }
    }
}
