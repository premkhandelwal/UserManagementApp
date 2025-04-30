using Microsoft.AspNetCore.Identity;
using System;
namespace Crm.Admin.Data.Models
{
    public class CrmIdentityUser : IdentityUser
    {
        public int UserId {  get; set; }
        public bool IsDeactivated { get; set; } = false;

        public string TenantId { get; set; } = Guid.NewGuid().ToString();
    }
}
