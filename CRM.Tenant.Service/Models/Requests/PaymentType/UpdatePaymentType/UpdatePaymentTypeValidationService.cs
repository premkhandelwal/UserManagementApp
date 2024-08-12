using Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.PaymentType.UpdatePaymentType
{
    public class UpdatePaymentTypeValidationService : CreatePaymentTypeValidationService<UpdatePaymentTypeRequest>
    {
        public UpdatePaymentTypeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
