using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Admin.Service.Models
{
    public class LoginResponse
    {
        public string? UserId { get; set; }
        public string? JwtAuthToken { get; set; }
        public string? RefreshToken { get; set; }
        public List<string> Permissions { get; set; } = new List<string>();
    }
}
