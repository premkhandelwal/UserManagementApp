using System.ComponentModel.DataAnnotations.Schema;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;

namespace Crm.Tenant.Data.Models.PurchaseOrder
{
    public class PurchaseOrderItemModel : BaseModelClass
    {
        public int PurchaseOrderId { get; set; }

        public int SrNo { get; set; }

        public string? Description1 { get; set; }

        public string? Description2 { get; set; }

        public double Quantity { get; set; }

        public int? Unit { get; set; }

        public int? Hsn {  get; set; }

        public string DeliveryStatus { get; set; } = "pending";

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        [ForeignKey(nameof(PurchaseOrderId))]
        public virtual PurchaseOrderFieldsModel? PurchaseOrderFieldsModel { get; set; }

        [ForeignKey(nameof(Hsn))]
        public virtual HsnModel? HsnModel { get; set; }
    }
}
