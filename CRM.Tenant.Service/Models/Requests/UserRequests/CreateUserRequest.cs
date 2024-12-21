namespace CRM.Tenant.Service.Models.Requests.UserRequests
{
    public class CreateUserRequest
    {
        public string Username { get; set; } = null!;

        public string EmailId { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public string Role { get; set; } = null!;

        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
