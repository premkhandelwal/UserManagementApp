using Crm.Tenant.Service.Models.Requests.Material.CreateMaterial;
using Crm.Tenant.Service.Models.Requests.Material.UpdateMaterial;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Currencies.UpdateCountry
{
    public class UpdateMaterialValidationService : CreateMaterialValidationService<UpdateMaterialRequest>
    {
        public UpdateMaterialValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
