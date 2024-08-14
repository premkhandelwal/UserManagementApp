using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.DeleteTransportMode
{
    public class DeleteTransportModeRequest : CreateTransportModeRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
