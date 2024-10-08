﻿namespace CRM.Tenant.Service.Models.Requests.MasterRequests.Currencies.CreateCurrency
{
    public class CreateCurrencyRequest
    {
        public string? CurrencyName { get; set; }
        public string? CurrencyRate { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
