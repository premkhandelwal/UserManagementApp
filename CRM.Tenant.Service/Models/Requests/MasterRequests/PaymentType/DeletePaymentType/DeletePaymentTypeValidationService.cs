using CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.CreatePaymentType;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PaymentType.DeletePaymentType
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
