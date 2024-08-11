using CRM.Tenant.Service.Models.Requests.Countries.CreateCountry;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Countries.DeleteCountry
{
    public class DeleteCountryValidationService: CreateCountryValidationService<DeleteCountryRequest>
    {
        public DeleteCountryValidationService() { 
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
