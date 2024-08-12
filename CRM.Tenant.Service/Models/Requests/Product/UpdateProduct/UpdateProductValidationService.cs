using Crm.Tenant.Service.Models.Requests.Product.CreateProduct;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Product.UpdateProduct
{
    public class UpdateProductValidationService : CreateProductValidationService<UpdateProductRequest>
    {
        public UpdateProductValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
