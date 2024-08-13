using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.UpdateTransportMode
{
    public class UpdateTransportModeRequest : CreateTransportModeRequest
    {
        public int? Id { get; set; }
    }
}
