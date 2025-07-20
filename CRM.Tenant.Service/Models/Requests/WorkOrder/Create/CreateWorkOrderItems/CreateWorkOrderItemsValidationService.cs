using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderItems
{
    public class CreateWorkOrderItemsValidationService<T>: AbstractValidator<T> where T : CreateWorkOrderItemsRequest
    {
        public CreateWorkOrderItemsValidationService()
    {
        RuleFor(x => x.AddedOn)
            .NotEmpty().WithMessage("Added on date is required.");

        RuleFor(x => x.ModifiedOn)
            .GreaterThanOrEqualTo(x => x.AddedOn).WithMessage("Modified on date must be after or equal to the added on date.");
    }
}
}
