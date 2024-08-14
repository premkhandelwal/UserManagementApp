using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency
{
    public class CreateCurrencyValidationService<T> : AbstractValidator<T> where T : CreateCurrencyRequest
    {
        public CreateCurrencyValidationService()
        {
            RuleFor(x => x.CurrencyName).NotEmpty().WithMessage("Currency name is required.");

        }
    }
}
