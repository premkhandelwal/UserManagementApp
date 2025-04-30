using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.UpdateVendor
{
    public class UpdateVendorValidationService: CreateVendorValidationService<UpdateVendorRequest>
    {
        public UpdateVendorValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }

}

