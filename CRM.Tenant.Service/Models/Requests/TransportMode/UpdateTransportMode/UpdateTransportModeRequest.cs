using Crm.Tenant.Service.Models.Requests.TransportMode.CreateTransportMode;

namespace Crm.Tenant.Service.Models.Requests.TransportMode.UpdateTransportMode
{
    public class UpdateTransportModeRequest : CreateTransportModeRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
