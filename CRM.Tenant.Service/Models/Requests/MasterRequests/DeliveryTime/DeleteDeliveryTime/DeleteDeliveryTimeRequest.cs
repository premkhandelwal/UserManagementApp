using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.DeleteDeliveryTime
{
    public class DeleteDeliveryTimeRequest : CreateDeliveryTimeRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
