﻿namespace Crm.Tenant.Data.Models.UserManagementRequests
{
    public class CreateRoleRequest
    {
        public string Role { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
