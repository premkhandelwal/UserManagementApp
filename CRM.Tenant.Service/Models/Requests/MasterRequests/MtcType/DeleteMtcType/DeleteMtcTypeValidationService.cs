using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.DeleteMtcType
{
    public class DeleteMtcTypeValidationService : CreateMtcTypeValidationService<DeleteMtcTypeRequest>
    {
        public DeleteMtcTypeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
