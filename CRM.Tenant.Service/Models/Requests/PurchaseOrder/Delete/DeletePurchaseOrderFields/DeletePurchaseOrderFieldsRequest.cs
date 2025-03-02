using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderFields
{
    public class DeletePurchaseOrderFieldsRequest : CreatePurchaseOrderFieldsRequest
    {
        public int? Id { get; set; }

        public bool IsDeleted = true;
    }
}
