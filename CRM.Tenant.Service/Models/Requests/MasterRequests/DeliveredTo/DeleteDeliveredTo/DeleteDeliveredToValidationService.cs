using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.DeleteDeliveredTo
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
