using FluentValidation;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.UpdateCurrency
{
    public class UpdateCurrencyValidationService : CreateCurrencyValidationService<UpdateCurrencyRequest>
    {
        public UpdateCurrencyValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
