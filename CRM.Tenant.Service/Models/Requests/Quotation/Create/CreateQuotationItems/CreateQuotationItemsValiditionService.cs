using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems
{
    public class CreateQuotationItemsValidationService<T> : AbstractValidator<T> where T : CreateQuotationItemsRequest
    {
        public CreateQuotationItemsValidationService()
        {
            RuleFor(x => x.QuotationId)
                .NotNull().WithMessage("Quotation ID is required.")
                .GreaterThan(0).WithMessage("Quotation ID must be greater than 0.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.AddedOn)
                .NotEmpty().WithMessage("Added on date is required.");

            RuleFor(x => x.ModifiedOn)
                .GreaterThanOrEqualTo(x => x.AddedOn).WithMessage("Modified on date must be after or equal to the added on date.");
        }
    }
}
