using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry
{
    public class CreateCountryValidationService<T> : AbstractValidator<T> where T : CreateCountryRequest
    {
        public CreateCountryValidationService()
        {
            RuleFor(x => x.CountryName).NotEmpty().WithMessage("Country name is required.");

        }
    }
}
