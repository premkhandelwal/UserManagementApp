using CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.DeleteCurrency
{
    public class DeleteCurrencyRequest : CreateCurrencyRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
