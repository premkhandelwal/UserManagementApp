using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create
{
    public class CreatePurchaseOrderRequest
    {
        public CreatePurchaseOrderFieldsRequest purchaseOrderFields { get; set; } = new CreatePurchaseOrderFieldsRequest();

        public List<CreatePurchaseOrderItemsRequest> purchaseOrderItems { get; set; } = new List<CreatePurchaseOrderItemsRequest>();

        public CreatePurchaseOrderTermsRequest purchaseOrderTerms { get; set; } = new CreatePurchaseOrderTermsRequest();
    }
}
