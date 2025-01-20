namespace CRM.Admin.Service.Models
{
    public class LoginResponse
    {
        public string? UserId { get; set; }
        public string? JwtAuthToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
