using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationTerms
{
    public class UpdateQuotationTermsRequest: CreateQuotationTermsRequest
    {
        public int? Id { get; set; }

    }
}
