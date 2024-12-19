using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.CreateHsn
{
    public class CreateHsnValidationService<T> : AbstractValidator<T> where T : CreateHsnRequest
    {
        public CreateHsnValidationService()
        {
            RuleFor(x => x.HsnName).NotEmpty().WithMessage("Hsn name is required.");

        }
    }
}
