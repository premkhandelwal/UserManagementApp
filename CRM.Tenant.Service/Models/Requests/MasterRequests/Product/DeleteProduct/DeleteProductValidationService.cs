using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Product.DeleteProduct
{
    public class DeleteProductValidationService : CreateProductValidationService<DeleteProductRequest>
    {
        public DeleteProductValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
