using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderItems
{
    public class DeletePurchaseOrderItemsRequest: CreatePurchaseOrderItemsRequest
    {
        public int? Id { get; set; }

        public bool IsDeleted = true;
    }
}
