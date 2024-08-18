using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationFields
{
    public class UpdateQuotationFieldsRequest: CreateQuotationFieldsRequest
    {
        public int? Id { get; set; }
        public string? QuotationStatus { get; set; }

        public int? QuotationCloseReasonId { get; set; }
    }
}
