using Crm.Admin.Service.Models;
using Crm.Tenant.Data.Models.Masters.PurchaseOrder;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.PurchaseOrder
{
    public class PurchaseOrderFieldsModel : BaseModelClass
    {

        public int? PurchaseOrderMadeById { get; set; }

        public int? PurchaseOrderAssignedToId { get; set; }

        public DateTime PurchaseOrderDate { get; set; }

        public int? PurchaseOrderVendorId { get; set; }

        public int? PurchaseOrderAttentionId { get; set; }

        public double? GstPercent { get; set; }

        public double? NetTotal { get; set; }

        public double? Discount { get; set; }

        public string? DiscountType { get; set; }

        public double? GstAmount { get; set; }

        public double? OtherCharges { get; set; }

        public double? GrandTotal { get; set; }

        [ForeignKey(nameof(PurchaseOrderMadeById))]
        public virtual UserModel? PurchaseOrderMadeByUserModel { get; set; }

        [ForeignKey(nameof(PurchaseOrderAssignedToId))]
        public virtual UserModel? PurchaseOrderAssignedToUserModel { get; set; }

        [ForeignKey(nameof(PurchaseOrderVendorId))]
        public virtual VendorModel? PurchaseOrderVendorModel { get; set; }

        [ForeignKey(nameof(PurchaseOrderAttentionId))]
        public virtual VendorMemberModel? PurchaseOrderVendorMemberModel { get; set; }
    }
}
