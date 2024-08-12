using Crm.Tenant.Service.Models.Requests.Currencies.UpdateCurrency;
using Crm.Tenant.Service.Models.Requests.Currencies.CreateCurrency;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Currencies.UpdateCurrency
{
    public class UpdateCurrencyValidationService : CreateCurrencyValidationService<UpdateCurrencyRequest>
    {
        public UpdateCurrencyValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
