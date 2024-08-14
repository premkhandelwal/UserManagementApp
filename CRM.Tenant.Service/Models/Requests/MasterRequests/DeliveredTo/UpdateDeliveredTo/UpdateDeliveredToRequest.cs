using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.UpdateDeliveredTo
{
    public class UpdateDeliveredToRequest : CreateDeliveredToRequest
    {
        public int? Id { get; set; }
    }
}
