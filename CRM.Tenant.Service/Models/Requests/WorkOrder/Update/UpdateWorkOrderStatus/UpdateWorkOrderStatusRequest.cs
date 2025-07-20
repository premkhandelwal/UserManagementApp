using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderStatus;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderStatus
{
    public class UpdateWorkOrderStatusRequest: CreateWorkOrderStatusRequest
    {
        public int? Id { get; set; }
        public string? InvoiceUpdatedBy { get; set; }
        public string? StickerUpdatedBy { get; set; }
        public string? OperationsUpdatedBy { get; set; }
        public string? TcUpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public byte[] RecordVersion { get; set; } = Array.Empty<byte>();
        public bool IsDeleted { get; set; } = false;
    }
}
