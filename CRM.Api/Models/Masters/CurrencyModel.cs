namespace CRM.Api.Models.Masters
{
    public class CurrencyModel
    {
        public string? Id { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencyRate { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
