using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderStatus
{
    public class CreateWorkOrderStatusValidationService<T> : AbstractValidator<T> where T : CreateWorkOrderStatusRequest
    {
        public CreateWorkOrderStatusValidationService()
        {
            RuleFor(x => x.AddedOn)
                .NotEmpty().WithMessage("Added on date is required.");

            RuleFor(x => x.ModifiedOn)
                .GreaterThanOrEqualTo(x => x.AddedOn).WithMessage("Modified on date must be after or equal to the added on date.");
        }
    }
}