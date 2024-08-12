using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.CreateQuotationCloseReason;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.QuotationCloseReason.DeleteQuotationCloseReason
{
    public class DeleteQuotationCloseReasonValidationService : CreateQuotationCloseReasonValidationService<DeleteQuotationCloseReasonRequest>
    {
        public DeleteQuotationCloseReasonValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
