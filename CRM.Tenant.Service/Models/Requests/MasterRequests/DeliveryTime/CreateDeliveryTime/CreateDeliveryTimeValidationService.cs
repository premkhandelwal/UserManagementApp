using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime
{
    public class CreateDeliveryTimeValidationService<T> : AbstractValidator<T> where T : CreateDeliveryTimeRequest
    {
        public CreateDeliveryTimeValidationService()
        {
            RuleFor(x => x.DeliveryTime).NotEmpty().WithMessage("DeliveryTime name is required.");

        }
    }
}
