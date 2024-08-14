using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.DeleteQuotationCloseReason
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
