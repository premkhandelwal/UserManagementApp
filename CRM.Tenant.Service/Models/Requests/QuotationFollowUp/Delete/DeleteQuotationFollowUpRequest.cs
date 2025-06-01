using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Create;

namespace CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Delete
{
    public class DeleteQuotationFollowUpRequest: CreateQuotationFollowUpRequest
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
