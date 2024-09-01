using Crm.Admin.Data.Models;
using Crm.Tenant.Data.Models;
using Crm.Tenant.Data.Models.Masters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Admin.Service.Models
{
    public class UserModel: BaseModelClass
    {
        public string? UserId { get; set; } = null!;
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string EmailId { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public string MobileNo { get; set; } = null!;
    }
}
