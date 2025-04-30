using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.DeleteVendorMember
{
    public class DeleteVendorMemberRequest: CreateVendorMemberRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
