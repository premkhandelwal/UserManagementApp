using Crm.Tenant.Service.Models.Requests.DeliveryTime.CreateDeliveryTime;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.DeliveryTime.DeleteDeliveryTime
{
    public class DeleteDeliveryTimeValidationService : CreateDeliveryTimeValidationService<DeleteDeliveryTimeRequest>
    {
        public DeleteDeliveryTimeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
