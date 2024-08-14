using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial
{
    public class CreateMaterialValidationService<T> : AbstractValidator<T> where T : CreateMaterialRequest
    {
        public CreateMaterialValidationService()
        {
            RuleFor(x => x.MaterialName).NotEmpty().WithMessage("Material name is required.");

        }
    }
}
