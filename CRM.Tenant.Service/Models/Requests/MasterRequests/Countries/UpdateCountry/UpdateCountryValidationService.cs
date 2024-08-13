using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.CreateCountry;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.UpdateCountry
{
    public class UpdateCountryValidationService : CreateCountryValidationService<UpdateCountryRequest>
    {
        public UpdateCountryValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
