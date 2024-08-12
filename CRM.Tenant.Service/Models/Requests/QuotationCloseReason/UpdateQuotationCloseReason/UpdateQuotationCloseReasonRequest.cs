using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.CreateQuotationCloseReason;

namespace Crm.Tenant.Service.Models.Requests.QuotationCloseReason.UpdateQuotationCloseReason
{
    public class UpdateQuotationCloseReasonRequest : CreateQuotationCloseReasonRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
