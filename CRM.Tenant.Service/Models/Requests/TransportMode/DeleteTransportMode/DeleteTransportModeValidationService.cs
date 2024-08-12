using Crm.Tenant.Service.Models.Requests.TransportMode.CreateTransportMode;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.TransportMode.DeleteTransportMode
{
    public class DeleteTransportModeValidationService : CreateTransportModeValidationService<DeleteTransportModeRequest>
    {
        public DeleteTransportModeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
