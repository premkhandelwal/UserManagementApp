using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.DeleteVendor
{
    public class DeleteVendorRequest: CreateVendorRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
