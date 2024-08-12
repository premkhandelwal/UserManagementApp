using Crm.Tenant.Service.Models.Requests.Currencies.CreateCurrency;
using FluentValidation;

namespace Crm.Tenant.Service.Models.Requests.Currencies.DeleteCurrency
{
    public class DeleteCurrencyValidationService : CreateCurrencyValidationService<DeleteCurrencyRequest>
    {
        public DeleteCurrencyValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
