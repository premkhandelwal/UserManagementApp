using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.MtcType.CreateMtcType
{
    public class CreateMtcTypeValidationService<T> : AbstractValidator<T> where T : CreateMtcTypeRequest
    {
        public CreateMtcTypeValidationService()
        {
            RuleFor(x => x.MtcType).NotEmpty().WithMessage("MtcType name is required.");

        }
    }
}
