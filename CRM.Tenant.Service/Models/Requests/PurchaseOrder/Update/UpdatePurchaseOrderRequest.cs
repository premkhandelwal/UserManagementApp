using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderFields;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderTerms;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update
{
    public class UpdatePurchaseOrderRequest
    {
        public UpdatePurchaseOrderFieldsRequest purchaseOrderFields { get; set; } = new UpdatePurchaseOrderFieldsRequest();

        public List<UpdatePurchaseOrderItemsRequest> purchaseOrderItems { get; set; } = new List<UpdatePurchaseOrderItemsRequest>();

        public UpdatePurchaseOrderTermsRequest purchaseOrderTerms { get; set; } = new UpdatePurchaseOrderTermsRequest();
    }
}
