using System.ComponentModel.DataAnnotations.Schema;
using Crm.Tenant.Data.Models;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;

namespace Crm.Api.Models.Quotation
{
    public class PurchaseOrderItemModel : BaseModelClass
    {
        public int PurchaseOrderId { get; set; }

        public int SrNo { get; set; }

        public string? Description1 { get; set; }

        public string? Description2 { get; set; }

        public double Quantity { get; set; }

        public string? Unit { get; set; }

        public int? HsnId {  get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        [ForeignKey(nameof(PurchaseOrderId))]
        public virtual PurchaseOrderFieldsModel? PurchaseOrderFieldsModel { get; set; }

        [ForeignKey(nameof(HsnId))]
        public virtual HsnModel? HsnModel { get; set; }
    }
}
