using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Admin.Data.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string JwtId { get; set; } = null!;
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public CrmIdentityUser User { get; set; } = null!;
    }
}
