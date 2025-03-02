using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderFields;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderTerms;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete
{
    public class DeletePurchaseOrderRequest
    {
        public DeletePurchaseOrderFieldsRequest purchaseOrderFields { get; set; } = new DeletePurchaseOrderFieldsRequest();

        public List<DeletePurchaseOrderItemsRequest> purchaseOrderItems { get; set; } = new List<DeletePurchaseOrderItemsRequest>();

        public DeletePurchaseOrderTermsRequest purchaseOrderTerms { get; set; } = new DeletePurchaseOrderTermsRequest();
    }
}
