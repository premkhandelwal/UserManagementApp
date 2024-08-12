using Crm.Tenant.Service.Models.Requests.DeliveryTime.CreateDeliveryTime;

namespace Crm.Tenant.Service.Models.Requests.DeliveryTime.DeleteDeliveryTime
{
    public class DeleteDeliveryTimeRequest : CreateDeliveryTimeRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
