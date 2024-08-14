using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields
{
    public class CreateQuotationFieldsValiditionService<T> : AbstractValidator<T> where T : CreateQuotationFieldsRequest
    {
        public CreateQuotationFieldsValiditionService()
        {
        }
    }
}
