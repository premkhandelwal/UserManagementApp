namespace CRM.Admin.Service.Models
{
    public class UserClaimsResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<ClaimResponse> Claims { get; set; }
    }
}
