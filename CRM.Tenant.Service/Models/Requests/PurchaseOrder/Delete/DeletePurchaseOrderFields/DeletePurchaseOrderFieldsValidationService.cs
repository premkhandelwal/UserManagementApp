using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderFields;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderFields
{
    public class DeletePurchaseOrderFieldsValidationService : CreatePurchaseOrderFieldsValidationService<DeletePurchaseOrderFieldsRequest>
    {
        public DeletePurchaseOrderFieldsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

