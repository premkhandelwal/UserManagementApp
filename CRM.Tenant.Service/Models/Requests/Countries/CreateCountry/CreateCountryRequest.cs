namespace Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry
{
    public class CreateCountryRequest
    {
        public string? CountryName { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
