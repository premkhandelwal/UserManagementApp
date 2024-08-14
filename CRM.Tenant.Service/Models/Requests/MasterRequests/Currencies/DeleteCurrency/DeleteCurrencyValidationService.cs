using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.DeleteCurrency
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
