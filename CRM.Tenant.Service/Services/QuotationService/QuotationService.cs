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

        public async Task<int?> Create(CreateQuotationRequest request)
        {
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
                return quotationFields.Id;
            }
            return -1;
        }

        public async Task<List<QuotationModel>> Get()
        {
            List<QuotationModel> result = new List<QuotationModel>();
           List<QuotationFieldsModel> quotationFields = await _quotationFields.ReadAsync();
           List<QuotationItemModel> quotationItems = await _quotationItems.ReadAsync();
           List<QuotationTermsModel> quotationTerms = await _quotationTerms.ReadAsync();
            foreach (var quotation in quotationFields)
            {
                int? id = quotation.Id;
                if (id != null)
                {
                   List<QuotationItemModel> qItems = quotationItems.Where(item => item.Id == id).ToList();
                    QuotationTermsModel? qTerms = quotationTerms.Where((item) => item.Id == id).FirstOrDefault();
                    result.Add(new QuotationModel() { 
                        quotationFields = quotation,
                        quotationItems = qItems,
                        quotationTerms = qTerms ?? new QuotationTermsModel()
                    
                    });
                }
            }
            return result;
        }
    }
}
