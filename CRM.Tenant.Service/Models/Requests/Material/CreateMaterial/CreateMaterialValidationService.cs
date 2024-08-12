using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Material.CreateMaterial
{
    public class CreateMaterialValidationService<T> : AbstractValidator<T> where T : CreateMaterialRequest
    {
        public CreateMaterialValidationService()
        {
            RuleFor(x => x.MaterialName).NotEmpty().WithMessage("Material name is required.");

        }
    }
}
