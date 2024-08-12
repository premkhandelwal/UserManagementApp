using Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo;

namespace Crm.Tenant.Service.Models.Requests.DeliveredTo.DeleteDeliveredTo
{
    public class DeleteDeliveredToRequest : CreateDeliveredToRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
