using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderItems;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.WorkOrder.Delete.DeleteWorkOrderItems
{
    internal class DeleteWorkOrderItemsValidationService : CreateWorkOrderItemsValidationService<DeleteWorkOrderItemsRequest>
    {
        public DeleteWorkOrderItemsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}