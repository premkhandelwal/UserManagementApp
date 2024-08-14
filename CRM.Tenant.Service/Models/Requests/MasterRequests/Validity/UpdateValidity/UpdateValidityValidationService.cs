using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.UpdateValidity
{
    public class UpdateValidityValidationService : CreateValidityValidationService<UpdateValidityRequest>
    {
        public UpdateValidityValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
