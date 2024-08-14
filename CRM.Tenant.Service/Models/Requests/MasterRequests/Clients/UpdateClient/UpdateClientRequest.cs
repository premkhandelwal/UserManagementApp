using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.UpdateClient
{
    public class UpdateClientRequest : CreateClientRequest
    {
        public int? Id { get; set; }

    }
}
