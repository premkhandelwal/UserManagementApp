using CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationTerms;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationTerms
{
    public class DeleteQuotationTermsValidationService : CreateQuotationTermsValidationService<DeleteQuotationTermsRequest>
    {
        public DeleteQuotationTermsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

