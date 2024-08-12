using Crm.Tenant.Service.Models.Requests.DeliveredTo.CreateDeliveredTo;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.DeliveredTo.DeleteDeliveredTo
{
    public class DeleteDeliveredToValidationService : CreateDeliveredToValidationService<DeleteDeliveredToRequest>
    {
        public DeleteDeliveredToValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
