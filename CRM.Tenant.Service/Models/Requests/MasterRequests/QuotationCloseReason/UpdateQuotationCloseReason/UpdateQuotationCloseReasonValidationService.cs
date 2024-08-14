using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.UpdateQuotationCloseReason
{
    public class UpdateQuotationCloseReasonValidationService : CreateQuotationCloseReasonValidationService<UpdateQuotationCloseReasonRequest>
    {
        public UpdateQuotationCloseReasonValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
