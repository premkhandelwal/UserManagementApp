using CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationFields;
using CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationItems;
using CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationTerms;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Delete
{
    public class DeleteQuotationRequest
    {
        public DeleteQuotationFieldsRequest quotationFields { get; set; } = new DeleteQuotationFieldsRequest();

        public List<DeleteQuotationItemsRequest> quotationItems { get; set; } = new List<DeleteQuotationItemsRequest>();

        public DeleteQuotationTermsRequest quotationTerms { get; set; } = new DeleteQuotationTermsRequest();
    }
}
