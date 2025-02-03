using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;

namespace CRM.Tenant.Service.Models.Requests.QuotationFollowUp.UpdateQuotationItems
{
    public class UpdateQuotationItemsRequest : CreateQuotationItemsRequest
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
