using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.DeleteValidity
{
    public class DeleteValidityValidationService : CreateValidityValidationService<DeleteValidityRequest>
    {
        public DeleteValidityValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
