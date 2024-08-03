using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Api.Models.Quotation
{
    public class QuotationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [ForeignKey("User")]
        public string? QuotationMadeById { get; set; }

        [ForeignKey("User")]
        public string? QuotationAssignedToId { get; set; }

        public DateTime QuotationDate { get; set; }

        public string? QuotationStage { get; set; }

        [ForeignKey("Company")]
        public string? QuotationCompanyId { get; set; }

        [ForeignKey("CompanyMember")]
        public string? QuotationAttentionId { get; set; }

        public string? Reference { get; set; }

        public string? QuotationImportance { get; set; }

        public int QuotationPriority { get; set; }

        public double GstPercent { get; set; }

        public double NetTotal { get; set; }

        public double Discount { get; set; }

        public string? DiscountType { get; set; }

        public double GstAmount { get; set; }

        public double OtherCharges { get; set; }

        public double GrandTotal { get; set; }

        public List<QuotationItemModel>? QuotationItems { get; set; }

        public QuotationTermsModel? QuotationTerms { get; set; }

    }
}
