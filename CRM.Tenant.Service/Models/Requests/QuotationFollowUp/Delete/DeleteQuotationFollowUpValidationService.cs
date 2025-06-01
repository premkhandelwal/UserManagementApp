using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Create;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Delete
{
    public class DeleteQuotationFollowUpValidationService: CreateQuotationFollowUpValidationService<DeleteQuotationFollowUpRequest>
    {
        public DeleteQuotationFollowUpValidationService() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
