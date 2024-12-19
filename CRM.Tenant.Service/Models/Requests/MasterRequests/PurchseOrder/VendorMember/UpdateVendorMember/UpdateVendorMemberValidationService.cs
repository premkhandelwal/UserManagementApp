using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.UpdateVendorMember
{
    public class UpdateVendorMemberValidationService: CreateVendorMemberValidationService<UpdateVendorMemberRequest>
    {
        public UpdateVendorMemberValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
