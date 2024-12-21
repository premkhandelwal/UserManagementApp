using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderItems
{
    public class UpdatePurchaseOrderItemsRequest : CreatePurchaseOrderItemsRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}