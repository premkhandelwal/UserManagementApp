using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo
{
    public class CreateDeliveredToValidationService<T> : AbstractValidator<T> where T : CreateDeliveredToRequest
    {
        public CreateDeliveredToValidationService()
        {
            RuleFor(x => x.DeliveryName).NotEmpty().WithMessage("Country name is required.");

        }
    }
}
