using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason
{
    public class CreateQuotationCloseReasonValidationService<T> : AbstractValidator<T> where T : CreateQuotationCloseReasonRequest
    {
        public CreateQuotationCloseReasonValidationService()
        {
            RuleFor(x => x.QuotationCloseReason).NotEmpty().WithMessage("Quotation Close Reason is required.");

        }
    }
}
