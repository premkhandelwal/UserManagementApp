using CRM.Tenant.Service.Models.Requests.Countries.CreateCountry;

namespace CRM.Tenant.Service.Models.Requests.Countries.UpdateCountry
{
    public class UpdateCountryRequest: CreateCountryRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
