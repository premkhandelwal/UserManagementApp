using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields
{
    public class CreatePurchaseOrderFieldsValidationService<T> : AbstractValidator<T> where T : CreatePurchaseOrderFieldsRequest
    {
        public CreatePurchaseOrderFieldsValidationService()
        {
            RuleFor(x => x.PurchaseOrderMadeById)
                .NotNull().WithMessage("Purchase Order Made By ID is required.")
                .GreaterThan(0).WithMessage("Purchase Order Made By ID must be greater than 0.");

            RuleFor(x => x.PurchaseOrderAssignedToId)
                .NotNull().WithMessage("Purchase Order Assigned To ID is required.")
                .GreaterThan(0).WithMessage("Purchase Order Assigned To ID must be greater than 0.");

            RuleFor(x => x.PurchaseOrderDate)
                .NotEmpty().WithMessage("Purchase Order Date is required.");

            RuleFor(x => x.PurchaseOrderVendorId)
                .NotNull().WithMessage("Vendor ID is required.")
                .GreaterThan(0).WithMessage("Vendor ID must be greater than 0.");

            RuleFor(x => x.PurchaseOrderAttentionId)
                .NotNull().WithMessage("Attention ID is required.")
                .GreaterThan(0).WithMessage("Attention ID must be greater than 0.");

            RuleFor(x => x.GstPercent)
                .GreaterThanOrEqualTo(0).WithMessage("GST Percent must be a positive value.");

            RuleFor(x => x.NetTotal)
                .GreaterThanOrEqualTo(0).WithMessage("Net Total must be a positive value.");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount must be a positive value.");


            RuleFor(x => x.GstAmount)
                .GreaterThanOrEqualTo(0).WithMessage("GST Amount must be a positive value.");

            RuleFor(x => x.OtherCharges)
                .GreaterThanOrEqualTo(0).WithMessage("Other Charges must be a positive value.");

            RuleFor(x => x.GrandTotal)
                .GreaterThanOrEqualTo(0).WithMessage("Grand Total must be a positive value.");

            RuleFor(x => x.AddedOn)
                .NotEmpty().WithMessage("Added on date is required.");

            RuleFor(x => x.ModifiedOn)
                .GreaterThanOrEqualTo(x => x.AddedOn).WithMessage("Modified on date must be after or equal to the added on date.");
        }
    }
}
