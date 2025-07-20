namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkFields
{
    public class CreateWorkOrderFieldsRequest
    {
        public string? WorkOrderId { get; set; }
        public int? WorkOrderCompanyId { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? Remarks { get; set; }
        public DateTime WorkOrderDate { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
