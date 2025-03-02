using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete.DeletePurchaseOrderTerms
{
    public class DeletePurchaseOrderTermsValidationService : CreatePurchaseOrderTermsValidationService<DeletePurchaseOrderTermsRequest>
    {
        public DeletePurchaseOrderTermsValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}

