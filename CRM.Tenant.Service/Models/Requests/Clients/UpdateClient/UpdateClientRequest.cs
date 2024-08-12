using Crm.Tenant.Service.Models.Requests.Clients.CreateClient;

namespace Crm.Tenant.Service.Models.Requests.Clients.UpdateClient
{
    public class UpdateClientRequest: CreateClientRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
