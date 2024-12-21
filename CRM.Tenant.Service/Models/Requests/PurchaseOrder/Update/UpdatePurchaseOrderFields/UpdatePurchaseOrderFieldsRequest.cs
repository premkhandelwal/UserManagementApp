using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderFields
{
    public class UpdatePurchaseOrderFieldsRequest: CreatePurchaseOrderFieldsRequest
    {
        public int? Id { get; set; }

    }
}
