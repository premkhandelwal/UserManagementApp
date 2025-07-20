using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields;
using FluentValidation;


namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderFields
{
    public class UpdatePurchaseOrderFieldsValidationService : CreatePurchaseOrderFieldsValidationService<UpdatePurchaseOrderFieldsRequest>
    {
        public UpdatePurchaseOrderFieldsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

