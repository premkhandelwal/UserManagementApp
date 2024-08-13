using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using System;
namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.DeleteClient
{
    public class DeleteClientRequest : CreateClientRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
