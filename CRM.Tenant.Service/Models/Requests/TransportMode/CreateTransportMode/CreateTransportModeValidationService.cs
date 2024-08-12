using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.TransportMode.CreateTransportMode
{
    public class CreateTransportModeValidationService<T> : AbstractValidator<T> where T : CreateTransportModeRequest
    {
        public CreateTransportModeValidationService()
        {
            RuleFor(x => x.TransportMode).NotEmpty().WithMessage("Transport Mode is required.");

        }
    }
}
