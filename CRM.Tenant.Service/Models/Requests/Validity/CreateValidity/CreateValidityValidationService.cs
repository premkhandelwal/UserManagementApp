using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Validity.CreateValidity
{
    public class CreateValidityValidationService<T> : AbstractValidator<T> where T : CreateValidityRequest
    {
        public CreateValidityValidationService()
        {
            RuleFor(x => x.Validity).NotEmpty().WithMessage("Validity name is required.");

        }
    }
}
