using Crm.Tenant.Service.Models.Requests.TransportMode.CreateTransportMode;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.TransportMode.UpdateTransportMode
{
    public class UpdateTransportModeValidationService : CreateTransportModeValidationService<UpdateTransportModeRequest>
    {
        public UpdateTransportModeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
