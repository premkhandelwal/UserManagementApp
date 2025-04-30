namespace CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems
{
    public class CreateQuotationItemsRequest
    {
        public int? QuotationId { get; set; }

        public int SrNo { get; set; }

        public string? Description { get; set; }

        public double Quantity { get; set; }

        public int? Unit { get; set; }

        public double Cost { get; set; }

        public double Margin { get; set; }

        public double PackagingCharges { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
