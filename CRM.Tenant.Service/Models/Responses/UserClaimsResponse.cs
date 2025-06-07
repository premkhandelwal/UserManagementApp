namespace CRM.Tenant.Service.Models.Responses
{
    public class UserClaimsResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<ClaimResponse> Claims { get; set; }
    }
}
