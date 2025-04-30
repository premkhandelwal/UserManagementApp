using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationFields
{
    public class UpdateQuotationFieldsValidationService : CreateQuotationFieldsValidationService<UpdateQuotationFieldsRequest>
    {
        public UpdateQuotationFieldsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
