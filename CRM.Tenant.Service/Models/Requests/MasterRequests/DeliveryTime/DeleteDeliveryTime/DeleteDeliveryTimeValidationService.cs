using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.DeleteDeliveryTime
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
