using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderTerms
{
    public class UpdatePurchaseOrderTermsRequest: CreatePurchaseOrderTermsRequest
    {
        public int? Id { get; set; }
    }
}
