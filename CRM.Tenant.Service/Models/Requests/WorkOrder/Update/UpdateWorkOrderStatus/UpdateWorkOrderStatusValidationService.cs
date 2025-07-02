using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderStatus;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderStatus
{
    public class UpdateWorkOrderStatusValidationService : CreateWorkOrderStatusValidationService<UpdateWorkOrderStatusRequest>
    {
        public UpdateWorkOrderStatusValidationService()
        {
            RuleFor(x => x.Id)
               .NotNull().WithMessage("Id is required.")
               .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.IsDeleted)
                .NotNull().WithMessage("IsDeleted must be specified.");
        }
    }
}