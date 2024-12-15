using AutoMapper;
using Crm.Api.Models.Quotation;
using Crm.Tenant.Data.Models.Quotation;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.Quotation.QuotationFields.CreateQuotationItems;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp;
using FluentValidation;

namespace CRM.Tenant.Service.Services.QuotationService
{
    public class QuotationFollowUpService : BaseService<CreateQuotationFollowUpRequest, QuotationFollowUpModel>
    {
        private QuotationService _quotationService;
        public QuotationFollowUpService(IMapper mapper, BaseRepository<QuotationFollowUpModel> qfRepository,  IValidator<CreateQuotationFollowUpRequest> validator, QuotationService quotationService)
            : base(mapper, qfRepository, validator)
        {
            _quotationService = quotationService;
        }
        public async Task<List<QuotationFollowUpModel>> GetFollowUpsForIdAsync(int quotationId){
            List<QuotationFollowUpModel> followUpList =  await ReadAsync();
            return followUpList.Where(fu => fu.QuotationId == quotationId).ToList();
        }

        public async Task<List<QuotationFollowUpModel>> GetFollowUpsForDate(DateTime dateTime, string userId) 
        {
            List<QuotationFollowUpModel> followUpList = await ReadAsync();
            followUpList = followUpList.Where(f => f.NextFollowUpDate.Date == dateTime.Date).ToList();
            var quotationIds = followUpList.Select(f => f.QuotationId).Distinct();
            var quotations = await Task.WhenAll(quotationIds.Select(id => _quotationService.GetQuotationById(id)));
            var todaysFollowUps = followUpList.Where(f => quotations.Any(q => q != null && (q.quotationFields.QuotationMadeById == userId || q.quotationFields.QuotationAssignedToId == userId ))).ToList();
            return todaysFollowUps;
        }
    }
}
