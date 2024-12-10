using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Tenant.Data.Models.UserManagementRequests
{
    public class AddClaimForRoleRequest
    {
        [Required]
        public string roleName { get; set; } = null!;

        [Required]
        public string claimValue { get; set; } = null!;
    }
}
