using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.CreatePartNumber;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.DeletePartNumber
{
    internal class DeletePartNumberValidationRequest: CreatePartNumberValidationService<DeletePartNumberRequest>
    {
        public DeletePartNumberValidationRequest()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
