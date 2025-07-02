namespace CRM.Tenant.Service.Models.Responses.WorkOrder
{
    public class WorkOrderStatusResponse
    {
        public int? Id { get; set; }
        public int WorkOrderId { get; set; }
        public string? WorkOrderNumber {  get; set; }
        public string? PurchaseOrderNumber {  get; set; }
        public int? WorkOrderCompanyId { get; set; }
        public string? InvoiceUpdatedBy { get; set; }
        public string? StickerUpdatedBy { get; set; }
        public string? OperationsUpdatedBy { get; set; }
        public string? TcUpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public byte[] RecordVersion { get; set; } = Array.Empty<byte>();
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
