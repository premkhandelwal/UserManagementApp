using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationItems
{
    public class UpdateQuotationItemsValidationService<T> : CreateQuotationItemsValidationService<UpdateQuotationItemsRequest>
    {
        public UpdateQuotationItemsValidationService()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.IsDeleted)
                .NotNull().WithMessage("IsDeleted must be specified.");
        }
    }
}
