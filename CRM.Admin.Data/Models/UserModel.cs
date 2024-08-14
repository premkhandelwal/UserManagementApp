using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Admin.Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;

        public string Role { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public CrmIdentityUser User { get; set; } = null!;

    }
}
