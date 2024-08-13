using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.UpdateDeliveryTime
{
    public class UpdateDeliveryTimeValidationService : CreateDeliveryTimeValidationService<UpdateDeliveryTimeRequest>
    {
        public UpdateDeliveryTimeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
