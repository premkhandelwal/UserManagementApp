using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems
{
    public class CreatePurchaseOrderItemsValidationService<T> : AbstractValidator<T> where T : CreatePurchaseOrderItemsRequest
    {
        public CreatePurchaseOrderItemsValidationService()
        {
            RuleFor(x => x.PurchaseOrderId)
                .NotNull().WithMessage("Purchase Order ID is required.")
                .GreaterThan(0).WithMessage("Purchase Order ID must be greater than 0.");

            RuleFor(x => x.Description1)
                .NotEmpty().WithMessage("Description1 is required.");

            RuleFor(x => x.Description2)
                .NotEmpty().WithMessage("Description2 is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Unit is required.");

            RuleFor(x => x.AddedOn)
                .NotEmpty().WithMessage("Added on date is required.");

            RuleFor(x => x.ModifiedOn)
                .GreaterThanOrEqualTo(x => x.AddedOn).WithMessage("Modified on date must be after or equal to the added on date.");
        }
    }
}
