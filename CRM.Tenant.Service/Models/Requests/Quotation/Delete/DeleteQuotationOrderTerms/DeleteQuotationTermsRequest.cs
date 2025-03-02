using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationTerms
{
    public class DeleteQuotationTermsRequest: CreateQuotationTermsRequest
    {
        public int? Id { get; set; }

        public bool IsDeleted = true;
    }
}
