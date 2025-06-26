namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderItems
{
    public class CreateWorkOrderItemsRequest
    {
        public int? WorkOrderId { get; set; }
        public string? SrNo { get; set; }
        public int PartNumber { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int DispatchedQuantity { get; set; }
        public int? Unit { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
