using CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationFields;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationFields
{
    public class DeleteQuotationFieldsValidationService : CreateQuotationFieldsValidationService<DeleteQuotationFieldsRequest>
    {
        public DeleteQuotationFieldsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

