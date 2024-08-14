﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Crm.Admin.Service.Models
{
    public class IUser
    {
        public string UserId { get; set; } = null!;
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string EmailId { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}
