using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.UpdateTransportMode
{
    public class UpdateTransportModeValidationService : CreateTransportModeValidationService<UpdateTransportModeRequest>
    {
        public UpdateTransportModeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
