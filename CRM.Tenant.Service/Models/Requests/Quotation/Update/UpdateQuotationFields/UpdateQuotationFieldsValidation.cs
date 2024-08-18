using CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationFields;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields
{
    public class UpdateQuotationFieldsValiditionService<T> : AbstractValidator<T> where T : UpdateQuotationFieldsRequest
    {
        public UpdateQuotationFieldsValiditionService()
        {
        }
    }
}
