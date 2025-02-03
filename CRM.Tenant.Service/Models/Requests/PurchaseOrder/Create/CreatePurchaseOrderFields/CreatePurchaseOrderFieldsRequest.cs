namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields
{
    public class CreatePurchaseOrderFieldsRequest
    {
        public string? PurchaseOrderId = "";

        public int? PurchaseOrderMadeById { get; set; }

        public int? PurchaseOrderAssignedToId { get; set; }

        public DateTime PurchaseOrderDate { get; set; }

        public int? PurchaseOrderVendorId { get; set; }

        public int? PurchaseOrderAttentionId { get; set; }

        public double? GstPercent { get; set; }

        public double? NetTotal { get; set; }

        public double? Discount { get; set; }

        public string? DiscountType { get; set; }

        public double? GstAmount { get; set; }

        public double? OtherCharges { get; set; }

        public double? GrandTotal { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
