using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.Countries.CreateCountry
{
    public class CreateCountryValidationService<T> : AbstractValidator<T> where T : CreateCountryRequest
    {
        public CreateCountryValidationService()
        {
            RuleFor(x => x.CountryName).NotEmpty().WithMessage("Country name is required.");

        }
    }
}
