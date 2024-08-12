
using Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo;

namespace Crm.Tenant.Service.Models.Requests.DeliveredTo.UpdateDeliveredTo
{
    public class UpdateDeliveredToRequest : CreateDeliveredToRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
