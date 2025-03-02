using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderTerms
{
    public class DeletePurchaseOrderTermsRequest: CreatePurchaseOrderTermsRequest
    {
        public int? Id { get; set; }
    }
}
