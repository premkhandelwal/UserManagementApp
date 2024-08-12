using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo
{
    public class CreateDeliveredToValidationService<T> : AbstractValidator<T> where T : CreateDeliveredToRequest
    {
        public CreateDeliveredToValidationService()
        {
            RuleFor(x => x.DeliveryName).NotEmpty().WithMessage("Country name is required.");

        }
    }
}
