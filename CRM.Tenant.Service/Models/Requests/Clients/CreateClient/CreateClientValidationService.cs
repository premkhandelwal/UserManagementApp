using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Clients.CreateClient
{
    public class CreateClientValidationService<T> : AbstractValidator<T> where T : CreateClientRequest
    {
        public CreateClientValidationService()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Client name is required.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country name is required.");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Region name is required.");
            RuleFor(x => x.Website).NotEmpty().WithMessage("Website name is required.");
            RuleFor(x => x.AddedOn).NotEmpty().WithMessage("Added date is required.");
        }
    }
}
