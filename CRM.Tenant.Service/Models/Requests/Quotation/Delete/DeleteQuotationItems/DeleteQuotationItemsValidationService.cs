using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationItems
{
    public class DeleteQuotationItemsValidationService : CreateQuotationItemsValidationService<DeleteQuotationItemsRequest>
    {
        public DeleteQuotationItemsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

