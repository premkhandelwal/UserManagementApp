using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Tenant.Data.Models.Quotation
{
    public class QuotationFollowUpModel : BaseModelClass
    {
        public int QuotationId { get; set; }
        public int SrNo { get; set; }
        public DateTime FollowUpDate { get; set; }
        public DateTime NextFollowUpDate { get; set; }
        public string? FollowUpDetails { get; set; }
        public string? FollowUpRemarks { get; set; }
        [ForeignKey(nameof(QuotationId))]
        public virtual QuotationFieldsModel? QuotationFieldsModel { get; set; }

    }
}
