using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderItems;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderItems
{
    public class UpdatePurchaseOrderItemsValidationService: CreatePurchaseOrderItemsValidationService<UpdatePurchaseOrderItemsRequest>
    {
        public UpdatePurchaseOrderItemsValidationService() 
        {
            RuleFor(x => x.Id)
               .NotNull().WithMessage("Id is required.")
               .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.IsDeleted)
                .NotNull().WithMessage("IsDeleted must be specified.");

        }
    }
}
