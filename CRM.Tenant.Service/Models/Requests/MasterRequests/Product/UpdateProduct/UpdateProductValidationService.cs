using CRM.Tenant.Service.Models.Requests.MasterRequests.Product.CreateProduct;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Product.UpdateProduct
{
    public class UpdateProductValidationService : CreateProductValidationService<UpdateProductRequest>
    {
        public UpdateProductValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
