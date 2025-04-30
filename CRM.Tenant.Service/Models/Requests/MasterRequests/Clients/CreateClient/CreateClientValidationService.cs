using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient
{
    public class CreateClientValidationService<T> : AbstractValidator<T> where T : CreateClientRequest
    {
        public CreateClientValidationService()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Client name is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Region name is required.");
            RuleFor(x => x.Website).NotEmpty().WithMessage("Website name is required.");
            RuleFor(x => x.AddedOn).NotEmpty().WithMessage("Added date is required.");
        }
    }
}
