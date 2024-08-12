using Crm.Tenant.Service.Models.Requests.Product.CreateProduct;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Product.DeleteProduct
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
