namespace Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo
{
    public class CreateDeliveredToRequest
    {
        public string? DeliveryName { get; set; }
        public int? TransportModeId { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
