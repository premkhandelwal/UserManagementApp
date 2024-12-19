using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember
{
    public class CreateVendorMemberValidationService<T> : AbstractValidator<T> where T : CreateVendorMemberRequest
    {
        public CreateVendorMemberValidationService() 
        {
            RuleFor(x => x.VendorId).NotEmpty().WithMessage("Client field is required.");
            RuleFor(x => x.MemberName).NotEmpty().WithMessage("Member name is required.");
        }
    }
}
