using Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Currencies.UpdateCountry
{
    public class UpdateCountryValidationService: CreateCountryValidationService<UpdateCountryRequest>
    {
        public UpdateCountryValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
