using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationItems
{
    public class UpdateQuotationItemsValidationService<T> : AbstractValidator<T> where T : UpdateQuotationItemsRequest
    {
    }
}
