using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.UpdateDeliveryTime
{
    public class UpdateDeliveryTimeRequest : CreateDeliveryTimeRequest
    {
        public int? Id { get; set; }
    }
}
