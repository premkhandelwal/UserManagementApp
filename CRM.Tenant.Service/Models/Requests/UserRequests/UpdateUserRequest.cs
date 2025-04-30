namespace CRM.Tenant.Service.Models.Requests.UserRequests
{
    public class UpdateUserRequest: CreateUserRequest
    {
        public string UserId { get; set; } = string.Empty;

        public int Id { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
