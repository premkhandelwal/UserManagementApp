using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.DeleteDeliveredTo
{
    public class DeleteDeliveredToRequest : CreateDeliveredToRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
