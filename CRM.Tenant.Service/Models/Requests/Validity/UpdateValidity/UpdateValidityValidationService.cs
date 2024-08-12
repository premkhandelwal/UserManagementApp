using Crm.Tenant.Service.Models.Requests.Validity.CreateValidity;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Validity.UpdateValidity
{
    public class UpdateValidityValidationService : CreateValidityValidationService<UpdateValidityRequest>
    {
        public UpdateValidityValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
