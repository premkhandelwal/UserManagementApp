using Crm.Tenant.Service.Models.Requests.Validity.CreateValidity;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Validity.DeleteValidity
{
    public class DeleteValidityValidationService : CreateValidityValidationService<DeleteValidityRequest>
    {
        public DeleteValidityValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
