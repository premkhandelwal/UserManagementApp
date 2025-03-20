using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Create;

namespace CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Update
{
    public class UpdateQuotationFollowUpRequest: CreateQuotationFollowUpRequest
    {
        public int? Id { get; set; }
    }
}
