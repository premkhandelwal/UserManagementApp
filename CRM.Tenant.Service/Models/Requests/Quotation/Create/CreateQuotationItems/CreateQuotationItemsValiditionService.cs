using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems
{
    public class CreateQuotationItemsValiditionService<T> : AbstractValidator<T> where T : CreateQuotationItemsRequest
    {
        public CreateQuotationItemsValiditionService()
        {
        }
    }
}