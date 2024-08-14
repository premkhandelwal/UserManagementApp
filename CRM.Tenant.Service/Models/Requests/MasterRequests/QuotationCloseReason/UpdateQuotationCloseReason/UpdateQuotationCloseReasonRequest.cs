using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.UpdateQuotationCloseReason
{
    public class UpdateQuotationCloseReasonRequest : CreateQuotationCloseReasonRequest
    {
        public int? Id { get; set; }
    }
}
