using Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry;

namespace Crm.Tenant.Service.Models.Requests.Currencies.UpdateCountry
{
    public class UpdateCountryRequest: CreateCountryRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
