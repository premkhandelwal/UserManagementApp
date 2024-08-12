using Crm.Tenant.Service.Models.Requests.Material.CreateMaterial;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Material.DeleteMaterial
{
    public class DeleteMaterialValidationService : CreateMaterialValidationService<DeleteMaterialRequest>
    {
        public DeleteMaterialValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
