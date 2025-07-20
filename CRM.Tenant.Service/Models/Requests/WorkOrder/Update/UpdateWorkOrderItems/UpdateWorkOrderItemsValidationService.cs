using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderItems;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderItems
{
    public class UpdateWorkOrderItemsValidationService : CreateWorkOrderItemsValidationService<UpdateWorkOrderItemsRequest>
    {
        public UpdateWorkOrderItemsValidationService()
        {
            RuleFor(x => x.Id)
               .NotNull().WithMessage("Id is required.")
               .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.IsDeleted)
                .NotNull().WithMessage("IsDeleted must be specified.");

        }
    }
}
