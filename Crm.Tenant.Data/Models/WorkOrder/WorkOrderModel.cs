namespace Crm.Tenant.Data.Models.WorkOrder
{
    public class WorkOrderModel
    {
        public WorkOrderFieldsModel workOrderFields { get; set; } = new WorkOrderFieldsModel();

        public List<WorkOrderItemModel> workOrderItems { get; set; } = new List<WorkOrderItemModel>();
    }
}
