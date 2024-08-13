using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct
{
    public class CreateProductValidationService<T> : AbstractValidator<T> where T : CreateProductRequest
    {
        public CreateProductValidationService()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name is required.");

        }
    }
}
