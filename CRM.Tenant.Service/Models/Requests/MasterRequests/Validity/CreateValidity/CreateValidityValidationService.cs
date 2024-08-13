using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity
{
    public class CreateValidityValidationService<T> : AbstractValidator<T> where T : CreateValidityRequest
    {
        public CreateValidityValidationService()
        {
            RuleFor(x => x.Validity).NotEmpty().WithMessage("Validity name is required.");

        }
    }
}
