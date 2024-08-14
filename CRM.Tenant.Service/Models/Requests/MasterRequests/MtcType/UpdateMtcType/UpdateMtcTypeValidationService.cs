using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.UpdateMtcType
{
    public class UpdateMtcTypeValidationService : CreateMtcTypeValidationService<UpdateMtcTypeRequest>
    {
        public UpdateMtcTypeValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
