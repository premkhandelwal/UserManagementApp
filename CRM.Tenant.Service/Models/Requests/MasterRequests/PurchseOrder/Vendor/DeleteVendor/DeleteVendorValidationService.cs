using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.DeleteClient;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.DeleteVendor
{
    internal class DeleteVendorValidationService : CreateClientValidationService<DeleteClientRequest>
    {
        public DeleteVendorValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }

}
