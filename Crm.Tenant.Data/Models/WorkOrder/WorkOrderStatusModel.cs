using Crm.Tenant.Data.Models.Masters.WorkOrder;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.WorkOrder
{
    public class WorkOrderStatusModel: BaseModelClass
    {
        public int WorkOrderId {  get; set; }
        public string? InvoiceUpdatedBy {  get; set; }
        public string? StickerUpdatedBy { get; set; }
        public string? OperationsUpdatedBy { get; set;}
        public string? TcUpdatedBy {  get; set; }
        public string? Remarks { get; set; }
        public byte[] RecordVersion { get; set; } = Array.Empty<byte>();
        
        [ForeignKey(nameof(WorkOrderId))]
        public virtual WorkOrderFieldsModel? WorkOrderModel { get; set; }
    }
}
