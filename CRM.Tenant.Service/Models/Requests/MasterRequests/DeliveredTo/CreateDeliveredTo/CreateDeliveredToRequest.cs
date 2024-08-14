namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo
{
    public class CreateDeliveredToRequest
    {
        public string? DeliveryName { get; set; }
        public int? TransportModeId { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
