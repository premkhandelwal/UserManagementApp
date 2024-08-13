using Crm.Tenant.Data.Models;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationTerms;

namespace CRM.Tenant.Service.Models.Requests.Quotation
{
    public class CreateQuotationRequest
    {
        public CreateQuotationFieldsRequest quotationFields { get; set; } = null!;
        public List<CreateQuotationItemsRequest> quotationItems { get; set; } = new List<CreateQuotationItemsRequest>();
        public CreateQuotationTermsRequest quotationTerms { get; set; } = null!;
    }
}
