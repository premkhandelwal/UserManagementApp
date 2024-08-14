using Crm.Api.Models.Quotation;
using Crm.Tenant.Data.Models.Quotation;
using CRM.Tenant.Service.Models.Requests.Quotation;

namespace CRM.Tenant.Service.Services.QuotationService
{
    public class QuotationService
    {
        QuotationFieldsService _quotationFields;
        QuotationItemsService _quotationItems;
        QuotationTermsService _quotationTerms;

        public QuotationService(QuotationFieldsService quotationFields,
        QuotationItemsService quotationItems, QuotationTermsService quotationTerms)
        {
            _quotationFields = quotationFields;
            _quotationItems = quotationItems;
            _quotationTerms = quotationTerms;
        }

        public async Task<QuotationModel?> Create(CreateQuotationRequest request)
        {
            QuotationModel? quotationModel = null!;
            QuotationFieldsModel? quotationFields = await _quotationFields.CreateAsync(request.quotationFields);
            List<QuotationItemModel> quotationItems = new List<QuotationItemModel> { };
            if (quotationFields != null && quotationFields.Id != null)
            {
                foreach (var item in request.quotationItems)
                {
                    item.QuotationId = quotationFields.Id;
                    QuotationItemModel? savedItem = await _quotationItems.CreateAsync(item);
                    if (savedItem != null)
                    {
                        quotationItems.Add(savedItem);
                    }
                }
                request.quotationTerms.QuotationId = quotationFields.Id;
                QuotationTermsModel? quotationTerms = await _quotationTerms.CreateAsync(request.quotationTerms);   
                if(quotationTerms != null)
                {
                    quotationModel = new QuotationModel()
                    {
                        quotationFields = quotationFields,
                        quotationTerms = quotationTerms,
                        quotationItems = quotationItems
                    };
                }
            }
            return quotationModel;
        }
    }
}
