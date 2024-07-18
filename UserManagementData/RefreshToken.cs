﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagementData;

namespace UserManagementApp.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Token {  get; set; } = null!;
        public string JwtId {  get; set; } = null!;
        public bool IsUsed {  get; set; }
        public bool IsRevoked {  get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
