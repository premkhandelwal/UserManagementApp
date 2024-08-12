using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType
{
    public class CreatePaymentTypeValidationService<T> : AbstractValidator<T> where T : CreatePaymentTypeRequest
    {
        public CreatePaymentTypeValidationService()
        {
            RuleFor(x => x.PaymentType).NotEmpty().WithMessage("PaymentType name is required.");

        }
    }
}
