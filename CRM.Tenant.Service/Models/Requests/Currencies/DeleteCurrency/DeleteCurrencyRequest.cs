using Crm.Tenant.Service.Models.Requests.Currencies.CreateCurrency;

namespace Crm.Tenant.Service.Models.Requests.Currencies.DeleteCurrency
{
    public class DeleteCurrencyRequest: CreateCurrencyRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
