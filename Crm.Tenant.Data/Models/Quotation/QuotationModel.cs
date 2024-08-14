using Crm.Api.Models.Quotation;

namespace Crm.Tenant.Data.Models.Quotation
{
    public class QuotationModel
    {
        public QuotationFieldsModel quotationFields { get; set; } = null!;
        public List<QuotationItemModel> quotationItems { get; set; } = new List<QuotationItemModel>();
        public QuotationTermsModel quotationTerms { get; set; } = null!;
    }
}
