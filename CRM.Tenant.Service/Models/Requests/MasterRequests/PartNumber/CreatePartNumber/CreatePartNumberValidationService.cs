using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.CreatePartNumber
{
    public class CreatePartNumberValidationService<T>: AbstractValidator<T> where T : CreatePartNumberRequest
    {
        public CreatePartNumberValidationService() 
        {
            RuleFor(x => x.PartName).NotEmpty().WithMessage("Part name is required.");
        }
    }
}
