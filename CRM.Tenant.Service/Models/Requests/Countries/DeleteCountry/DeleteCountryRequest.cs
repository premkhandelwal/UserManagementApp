using CRM.Tenant.Service.Models.Requests.Countries.CreateCountry;

namespace CRM.Tenant.Service.Models.Requests.Countries.DeleteCountry
{
    public class DeleteCountryRequest: CreateCountryRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
