using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Unit.CreateUnit
{
    public class CreateUnitValidationService<T> : AbstractValidator<T> where T : CreateUnitRequest 
    {
        public CreateUnitValidationService() 
        {
            RuleFor(x => x.UnitName).NotEmpty().WithMessage("Unit name is required.");
        }
    }
}
