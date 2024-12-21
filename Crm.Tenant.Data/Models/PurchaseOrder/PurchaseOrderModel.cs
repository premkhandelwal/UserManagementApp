using Crm.Api.Models.Quotation;

namespace Crm.Tenant.Data.Models.PurchaseOrder
{
    public class PurchaseOrderModel
    {
        public PurchaseOrderFieldsModel purchaseOrderFields { get; set; } = new PurchaseOrderFieldsModel();

        public List<PurchaseOrderItemModel> purchaseOrderItems { get; set; } = new List<PurchaseOrderItemModel>();

        public PurchaseOrderTermsModel purchaseOrderTerms { get; set; } = new PurchaseOrderTermsModel();

    }
}
