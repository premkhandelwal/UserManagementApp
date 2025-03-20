using CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationFields;
using CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationItems;
using CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationTerms;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Update
{
    public class UpdateQuotationRequest
    {
        public UpdateQuotationFieldsRequest quotationFields { get; set; } = null!;
        public List<UpdateQuotationItemsRequest> quotationItems { get; set; } = new List<UpdateQuotationItemsRequest>();
        public UpdateQuotationTermsRequest quotationTerms { get; set; } = null!;
    }
}
