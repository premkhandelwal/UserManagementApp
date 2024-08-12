using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Crm.Tenant.Data.Models.Masters;

namespace Crm.Api.Models.Quotation
{
    public class QuotationTermsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int QuotationId { get; set; }
        public int? DelieveryNameId { get; set; }
        public int? CurrencyId { get; set; }
        public int? DeliveryTimeId { get; set; }
        public int? CountryofOriginId { get; set; }
        public int? PaymentId { get; set; }
        public int? MtcTypeId { get; set; }
        public int? ValidityId { get; set; }
        public int? PackingTypeId { get; set; }

        [ForeignKey(nameof(DelieveryNameId))]
        public virtual DeliveredToModel? DeliveredToModel { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public virtual CurrencyModel? CurrencyModel { get; set; }
        
        [ForeignKey(nameof(DeliveryTimeId))]
        public virtual DeliveryTimeModel? DeliveryTimeModel { get; set; }
        
        [ForeignKey(nameof(CountryofOriginId))]
        public virtual CountryModel? CountryofOriginModel { get; set; }

        [ForeignKey(nameof(PaymentId))]
        public virtual PaymentTypeModel? PaymentTypeModel { get; set; }

        [ForeignKey(nameof(MtcTypeId))]
        public virtual MtcTypeModel? MtcTypeModel { get; set; }

        [ForeignKey(nameof(ValidityId))]
        public virtual ValidityModel? ValidityModel { get; set; }

        [ForeignKey(nameof(PackingTypeId))]
        public virtual TransportModeModel? PackingTypeModel { get; set; }
    }
}
