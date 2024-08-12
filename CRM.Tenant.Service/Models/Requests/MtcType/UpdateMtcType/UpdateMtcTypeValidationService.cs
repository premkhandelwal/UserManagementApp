using Crm.Tenant.Service.Models.Requests.MtcType.CreateMtcType;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.MtcType.UpdateMtcType
{
    public class UpdateMtcTypeValidationService : CreateMtcTypeValidationService<UpdateMtcTypeRequest>
    {
        public UpdateMtcTypeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
