using Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Currencies.DeleteCountry
{
    public class DeleteCountryValidationService: CreateCountryValidationService<DeleteCountryRequest>
    {
        public DeleteCountryValidationService() { 
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
