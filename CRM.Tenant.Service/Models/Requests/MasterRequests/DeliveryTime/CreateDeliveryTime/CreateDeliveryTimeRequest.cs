namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime
{
    public class CreateDeliveryTimeRequest
    {
        public string? DeliveryTime { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
