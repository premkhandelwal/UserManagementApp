using CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.CreateCountry;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.DeleteCountry
{
    public class DeleteCountryRequest : CreateCountryRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
