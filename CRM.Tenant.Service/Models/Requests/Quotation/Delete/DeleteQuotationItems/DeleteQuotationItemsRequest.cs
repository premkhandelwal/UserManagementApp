using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;

namespace CRM.Tenant.Service.Models.Requests.Quotation.Delete.DeleteQuotationItems
{
    public class DeleteQuotationItemsRequest: CreateQuotationItemsRequest
    {
        public int? Id { get; set; }

        public bool IsDeleted = true;
    }
}
