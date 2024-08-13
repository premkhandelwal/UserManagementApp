using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.UpdateCurrency
{
    public class UpdateCurrencyRequest : CreateCurrencyRequest
    {
        public int? Id { get; set; }
    }
}
