using Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.PaymentType.DeletePaymentType
{
    public class DeletePaymentTypeValidationService : CreatePaymentTypeValidationService<DeletePaymentTypeRequest>
    {
        public DeletePaymentTypeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
