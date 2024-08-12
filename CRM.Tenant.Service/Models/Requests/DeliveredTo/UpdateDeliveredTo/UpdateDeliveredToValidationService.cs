using Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.DeliveredTo.UpdateDeliveredTo
{
    public class UpdateDeliveredToValidationService : CreateDeliveredToValidationService<UpdateDeliveredToRequest>
    {
        public UpdateDeliveredToValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
