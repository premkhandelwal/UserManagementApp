using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderItems
{
    public class DeletePurchaseOrderItemsValidationService : CreatePurchaseOrderItemsValidationService<DeletePurchaseOrderItemsRequest>
    {
        public DeletePurchaseOrderItemsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}