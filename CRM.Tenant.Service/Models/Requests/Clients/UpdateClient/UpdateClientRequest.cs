using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;

namespace CRM.Tenant.Service.Models.Requests.Clients.UpdateClient
{
    public class UpdateClientRequest: CreateClientRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
