using Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry;

namespace Crm.Tenant.Service.Models.Requests.Currencies.DeleteCountry
{
    public class DeleteCountryRequest: CreateCountryRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
