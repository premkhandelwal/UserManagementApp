namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderStatus
{
    public class CreateWorkOrderStatusRequest
    {
        public int WorkOrderId { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
