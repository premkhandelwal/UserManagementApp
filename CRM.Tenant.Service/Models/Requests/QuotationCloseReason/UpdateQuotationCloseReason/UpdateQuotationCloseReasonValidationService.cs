using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.CreateQuotationCloseReason;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.QuotationCloseReason.UpdateQuotationCloseReason
{
    public class UpdateQuotationCloseReasonValidationService : CreateQuotationCloseReasonValidationService<UpdateQuotationCloseReasonRequest>
    {
        public UpdateQuotationCloseReasonValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
