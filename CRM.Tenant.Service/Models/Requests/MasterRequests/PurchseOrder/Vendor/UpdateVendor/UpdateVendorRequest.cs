using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.UpdateVendor
{
    public class UpdateVendorRequest: CreateVendorRequest
    {
        public int? Id { get; set; }
    }
}
