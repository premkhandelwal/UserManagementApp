using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationTerms
{
    public class UpdateQuotationTermsValidationService<T> : AbstractValidator<T> where T : UpdateQuotationTermsRequest
    {
    }
}
