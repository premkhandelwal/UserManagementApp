using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.CreateCountry;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.UpdateCountry
{
    public class UpdateCountryRequest : CreateCountryRequest
    {
        public int? Id { get; set; }
    }
}
