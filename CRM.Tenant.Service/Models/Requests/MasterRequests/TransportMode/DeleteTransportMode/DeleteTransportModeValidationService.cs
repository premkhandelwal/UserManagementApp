using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.DeleteTransportMode
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
