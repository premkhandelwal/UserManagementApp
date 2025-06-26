using Crm.Tenant.Data.Models.Masters.WorkOrder;
using Crm.Tenant.Data.Models.PurchaseOrder;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.WorkOrder
{
    public class WorkOrderItemModel: BaseModelClass
    {
        public int WorkOrderId { get; set; }
        public string? SrNo { get; set; }
        public int PartNumber {  get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int DispatchedQuantity { get; set; }
        public int? Unit { get; set; }
        [ForeignKey(nameof(WorkOrderId))]
        public virtual WorkOrderFieldsModel? WorkOrderFieldsModel { get; set; }
        [ForeignKey(nameof(PartNumber))]
        public virtual PartNumberModel? PartNumberModel { get; set; }

    }
}
