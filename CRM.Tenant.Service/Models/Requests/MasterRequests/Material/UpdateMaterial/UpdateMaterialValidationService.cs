using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Material.UpdateMaterial
{
    public class UpdateMaterialValidationService : CreateMaterialValidationService<UpdateMaterialRequest>
    {
        public UpdateMaterialValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
