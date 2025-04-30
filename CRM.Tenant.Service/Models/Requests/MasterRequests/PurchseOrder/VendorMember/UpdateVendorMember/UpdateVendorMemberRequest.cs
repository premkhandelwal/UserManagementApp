using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.UpdateVendorMember
{
    public class UpdateVendorMemberRequest : CreateVendorMemberRequest
    {
        public int? Id { get; set; }
    }
}
