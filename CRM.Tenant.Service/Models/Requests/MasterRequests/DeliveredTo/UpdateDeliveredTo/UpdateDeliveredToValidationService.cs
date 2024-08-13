using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.UpdateDeliveredTo
{
    public class UpdateDeliveredToValidationService : CreateDeliveredToValidationService<UpdateDeliveredToRequest>
    {
        public UpdateDeliveredToValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
