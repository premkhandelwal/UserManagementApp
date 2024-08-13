namespace CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason
{
    public class CreateQuotationCloseReasonRequest
    {
        public string? QuotationCloseReason { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
