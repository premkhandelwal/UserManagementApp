using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.CreatePaymentType;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.UpdatePaymentType
{
    public class UpdatePaymentTypeValidationService : CreatePaymentTypeValidationService<UpdatePaymentTypeRequest>
    {
        public UpdatePaymentTypeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
