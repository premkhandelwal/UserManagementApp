using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementData
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeactivated { get; set; } = false;

        public string TenantId {  get; set; } = Guid.NewGuid().ToString();
    }
}
