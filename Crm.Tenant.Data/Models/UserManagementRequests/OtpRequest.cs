namespace Crm.Tenant.Data.Models.UserManagementRequests
{
    public class OtpRequest
    {
        public string Email{ get; set; } = null!;
    }

    public class OtpValidationRequest
    {
        public string Email { get; set; } = null!;
        public string Otp { get; set; } = null!;
    }
}
