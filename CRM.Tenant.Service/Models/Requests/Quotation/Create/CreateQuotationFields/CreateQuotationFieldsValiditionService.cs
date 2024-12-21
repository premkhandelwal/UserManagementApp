using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields
{
    public class CreateQuotationFieldsValidationService<T> : AbstractValidator<T> where T : CreateQuotationFieldsRequest
    {
        public CreateQuotationFieldsValidationService()
        {
            RuleFor(x => x.QuotationMadeById)
                .NotEmpty().WithMessage("Quotation made by ID is required.");

            RuleFor(x => x.QuotationAssignedToId)
                .NotEmpty().WithMessage("Quotation assigned to ID is required.");

            RuleFor(x => x.QuotationDate)
                .NotEmpty().WithMessage("Quotation date is required.");

            RuleFor(x => x.QuotationStage)
                .NotEmpty().WithMessage("Quotation stage is required.");

            RuleFor(x => x.QuotationCompanyId)
                .NotNull().WithMessage("Quotation company ID is required.")
                .GreaterThan(0).WithMessage("Quotation company ID must be greater than 0.");

            RuleFor(x => x.QuotationAttentionId)
                .NotNull().WithMessage("Quotation attention ID is required.")
                .GreaterThan(0).WithMessage("Quotation attention ID must be greater than 0.");


            RuleFor(x => x.QuotationImportance)
                .NotNull().WithMessage("Quotation importance is required.")
                .MaximumLength(100).WithMessage("Quotation importance must not exceed 100 characters.");

            RuleFor(x => x.QuotationPriority)
                .InclusiveBetween(1, 5).WithMessage("Quotation priority must be between 1 and 5.");

            RuleFor(x => x.GstPercent)
                .GreaterThanOrEqualTo(0).WithMessage("GST percent must be a positive value.");

            RuleFor(x => x.NetTotal)
                .GreaterThanOrEqualTo(0).WithMessage("Net total must be a positive value.");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount must be a positive value.");

            RuleFor(x => x.DiscountType)
                .MaximumLength(50).WithMessage("Discount type must not exceed 50 characters.");

            RuleFor(x => x.GstAmount)
                .GreaterThanOrEqualTo(0).WithMessage("GST amount must be a positive value.");

            RuleFor(x => x.OtherCharges)
                .GreaterThanOrEqualTo(0).WithMessage("Other charges must be a positive value.");

            RuleFor(x => x.GrandTotal)
                .GreaterThanOrEqualTo(0).WithMessage("Grand total must be a positive value.");

            RuleFor(x => x.AddedOn)
                .NotEmpty().WithMessage("Added on date is required.");

            RuleFor(x => x.ModifiedOn)
                .GreaterThanOrEqualTo(x => x.AddedOn).WithMessage("Modified on date must be after or equal to the added on date.");
        }
    }
}
