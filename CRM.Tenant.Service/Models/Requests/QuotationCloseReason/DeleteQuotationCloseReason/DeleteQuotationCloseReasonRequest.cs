using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.CreateQuotationCloseReason;

namespace Crm.Tenant.Service.Models.Requests.QuotationCloseReason.DeleteQuotationCloseReason
{
    public class DeleteQuotationCloseReasonRequest : CreateQuotationCloseReasonRequest
    {
        public int? Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
