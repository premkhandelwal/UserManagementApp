using Crm.Tenant.Service.Models.Requests.DeliveryTime.CreateDeliveryTime;

namespace Crm.Tenant.Service.Models.Requests.DeliveryTime.UpdateDeliveryTime
{
    public class UpdateDeliveryTimeRequest : CreateDeliveryTimeRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
