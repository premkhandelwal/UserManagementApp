namespace CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Create
{
    public class CreateQuotationFollowUpRequest
    {
        public int QuotationId { get; set; }
        public DateTime QuotationDate { get; set; }
        public DateTime FollowUpDate { get; set; }
        public DateTime NextFollowUpDate { get; set; }
        public string? FollowUpDetails { get; set; }
        public string? FollowUpRemarks { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
