namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems
{
    public class CreatePurchaseOrderItemsRequest
    {
        public int? PurchaseOrderId { get; set; }

        public int SrNo { get; set; }

        public string? Description1 { get; set; }

        public string? Description2 { get; set; }

        public double Quantity { get; set; }

        public string? Unit { get; set; }

        public int? Hsn { get; set; }

        public string DeliveryStatus { get; set; } = "pending";

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        public DateTime? AddedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
