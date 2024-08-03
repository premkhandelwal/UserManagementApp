using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Api.Models.Quotation
{
    public class QuotationTermsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("QuotationModel")]
        public int QuotationId { get; set; }
        public string? DelieveryNameId { get; set; }
        public string? CurrencyId { get; set; }
        public string? DeliveryTimeId { get; set; }
        public string? CountryofOriginId { get; set; }
        public string? PaymentId { get; set; }
        public string? MtcTypeId { get; set; }
        public string? ValidityId { get; set; }
        public string? PackingTypeId { get; set; }
        public QuotationModel? Quotation { get; set; }
    }
}
