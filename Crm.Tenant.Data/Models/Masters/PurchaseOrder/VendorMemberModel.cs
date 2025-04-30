using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.Masters.PurchaseOrder
{
    public class VendorMemberModel: BaseModelClass
    {
        public int? VendorId { get; set; }
        public string? MemberName { get; set; }
        public string? Designation { get; set; }
        public string? Email {  get; set; }
        public string? Mobile { get; set; }
        public bool IsWhatsApp { get; set; }
        public string? SkypeId { get; set; }
        public string? Telephone { get; set; }
        public bool IsMainSeller { get; set; }
        public string? PMOC { get; set; }

        [ForeignKey(nameof(VendorId))]
        public virtual VendorModel? Vendor { get; set; }
    }
}
