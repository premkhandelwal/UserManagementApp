using Crm.Tenant.Service.Models.Requests.TransportMode.CreateTransportMode;

namespace Crm.Tenant.Service.Models.Requests.TransportMode.DeleteTransportMode
{
    public class DeleteTransportModeRequest : CreateTransportModeRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
