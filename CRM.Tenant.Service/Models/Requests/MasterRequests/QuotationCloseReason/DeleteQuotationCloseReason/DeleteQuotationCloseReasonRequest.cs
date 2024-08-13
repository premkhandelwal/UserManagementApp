using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.DeleteQuotationCloseReason
{
    public class DeleteQuotationCloseReasonRequest : CreateQuotationCloseReasonRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
