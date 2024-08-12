using Crm.Tenant.Service.Models.Requests.Currencies.CreateCurrency;

namespace Crm.Tenant.Service.Models.Requests.Currencies.UpdateCurrency
{
    public class UpdateCurrencyRequest : CreateCurrencyRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
