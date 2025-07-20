using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.CreatePartNumber;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.DeletePartNumber;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.UpdatePartNumber
{
    public class UpdatePartNumberValidationService : CreatePartNumberValidationService<DeletePartNumberRequest>
    {
        public UpdatePartNumberValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
