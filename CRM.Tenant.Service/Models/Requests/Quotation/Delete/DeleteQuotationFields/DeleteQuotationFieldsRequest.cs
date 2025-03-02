using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationFields;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationFields
{
    public class DeleteQuotationFieldsRequest : CreateQuotationFieldsRequest
    {
        public int? Id { get; set; }

        public bool IsDeleted = true;
    }
}
