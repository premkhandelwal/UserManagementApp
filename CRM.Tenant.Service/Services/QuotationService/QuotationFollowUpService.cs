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
        public QuotationFollowUpService(IMapper mapper, BaseRepository<QuotationFollowUpModel> repository, IValidator<CreateQuotationFollowUpRequest> validator)
            : base(mapper, repository, validator)
        {
        }
        public async override Task<List<QuotationFollowUpModel>> GetByIdAsync(int quotationId){
            List<QuotationFollowUpModel> followUpList =  await ReadAsync();
            return followUpList.Where(fu => fu.QuotationId == quotationId).ToList();
        }
    }
}
