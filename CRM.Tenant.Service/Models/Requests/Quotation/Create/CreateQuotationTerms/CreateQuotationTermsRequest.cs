using CRM.Tenant.Service.Services;

namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms
{
    public class CreateQuotationTermsRequest
    {
        public int? QuotationId { get; set; }
        public int? DeliveryNameId { get; set; }
        public int? CurrencyId { get; set; }
        public int? DeliveryTimeId { get; set; }
        public int? CountryofOriginId { get; set; }
        public int? PaymentId { get; set; }
        public int? MtcTypeId { get; set; }
        public int? ValidityId { get; set; }
        public int? PackingTypeId { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
