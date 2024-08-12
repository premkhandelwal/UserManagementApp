using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Product.CreateProduct
{
    public class CreateProductValidationService<T> : AbstractValidator<T> where T : CreateProductRequest
    {
        public CreateProductValidationService()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name is required.");

        }
    }
}
