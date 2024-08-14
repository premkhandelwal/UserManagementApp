namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient
{
    public class CreateClientRequest
    {
        public string? CompanyName { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Website { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
