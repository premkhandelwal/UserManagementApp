using Crm.Tenant.Service.Models.Requests.MtcType.CreateMtcType;
using Crm.Tenant.Service.Models.Requests.MtcType.UpdateMtcType;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.MtcType.DeleteMtcType
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
