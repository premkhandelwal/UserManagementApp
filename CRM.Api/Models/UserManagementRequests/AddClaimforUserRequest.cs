﻿using System.ComponentModel.DataAnnotations;

namespace CRM.Api.Models.UserManagementRequests
{
    public class AddClaimforUserRequest
    {
        [Required]
        public string emailId { get; set; } = null!;

        [Required]
        public string claimName { get; set; } = null!;

        [Required]
        public string claimValue { get; set; } = null!;
    }
}
