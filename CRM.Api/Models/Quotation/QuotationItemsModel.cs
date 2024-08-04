using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Api.Models.Quotation
{
    public class QuotationItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Added primary key

        [ForeignKey("QuotationModel")]
        public int QuotationId { get; set; } 

        public int SrNo { get; set; }

        public string? Description { get; set; }

        public double Quantity { get; set; }

        public string? Unit { get; set; }

        public double Cost { get; set; }

        public double Margin { get; set; }

        public double PackagingCharges { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        public QuotationModel? Quotation { get; set; }
    }
}
