using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Admin.Data.Models
{
    public class CrmIdentityUser : IdentityUser
    {
        public bool IsDeactivated { get; set; } = false;

        public string TenantId { get; set; } = Guid.NewGuid().ToString();
    }
}
