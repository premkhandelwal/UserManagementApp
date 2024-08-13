namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Countries.CreateCountry
{
    public class CreateCountryRequest
    {
        public string? CountryName { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
