using Crm.Tenant.Service.Models.Requests.DeliveryTime.CreateDeliveryTime;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.DeliveryTime.UpdateDeliveryTime
{
    public class UpdateDeliveryTimeValidationService : CreateDeliveryTimeValidationService<UpdateDeliveryTimeRequest>
    {
        public UpdateDeliveryTimeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
