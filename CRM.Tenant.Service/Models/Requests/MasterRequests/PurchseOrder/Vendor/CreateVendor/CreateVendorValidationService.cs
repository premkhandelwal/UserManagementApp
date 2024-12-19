using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor
{
    public class CreateVendorValidationService<T> : AbstractValidator<T> where T : CreateVendorRequest
    {
        public CreateVendorValidationService()
        {
            RuleFor(x => x.VendorName).NotEmpty().WithMessage("Vendor name is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.GstNo).NotEmpty().WithMessage("GST No is required.");
            RuleFor(x => x.ContactNo).NotEmpty().WithMessage("Contact No is required.");
            RuleFor(x => x.AddedOn).NotEmpty().WithMessage("Added date is required.");
        }
    }
}