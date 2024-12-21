using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create.CreatePurchaseOrderTerms
{
    public class CreatePurchaseOrderTermsValidationService<T> : AbstractValidator<T> where T : CreatePurchaseOrderTermsRequest
    {
        public CreatePurchaseOrderTermsValidationService()
        {
        }
    }
}
