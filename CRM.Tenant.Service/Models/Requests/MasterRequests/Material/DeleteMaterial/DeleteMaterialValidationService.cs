using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Material.DeleteMaterial
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
