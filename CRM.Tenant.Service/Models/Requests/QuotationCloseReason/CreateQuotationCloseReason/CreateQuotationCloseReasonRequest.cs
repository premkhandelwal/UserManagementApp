namespace Crm.Tenant.Service.Models.Requests.QuotationCloseReason.CreateQuotationCloseReason
{
    public class CreateQuotationCloseReasonRequest
    {
        public string? QuotationCloseReason { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
