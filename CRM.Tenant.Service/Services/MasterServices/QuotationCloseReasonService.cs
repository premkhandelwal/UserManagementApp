using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.QuotationCloseReason.CreateQuotationCloseReason;
using FluentValidation;

public class QuotationCloseReasonService : BaseService<CreateQuotationCloseReasonRequest, QuotationCloseReasonModel>
{
    public QuotationCloseReasonService(IMapper mapper, BaseRepository<QuotationCloseReasonModel> repository, IValidator<CreateQuotationCloseReasonRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}