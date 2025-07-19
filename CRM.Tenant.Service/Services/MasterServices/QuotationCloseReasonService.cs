using AutoMapper;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Services.QuotationService;
using FluentValidation;

public class QuotationCloseReasonService : BaseService<CreateQuotationCloseReasonRequest, QuotationCloseReasonModel>
{
    QuotationFieldsService _quotationFieldsService;
    public QuotationCloseReasonService(IMapper mapper, BaseRepository<QuotationCloseReasonModel> repository, IValidator<CreateQuotationCloseReasonRequest> validator, QuotationFieldsService quotationFieldsService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor): base(mapper, repository, validator, unitOfWork, httpContextAccessor)
    {
        _quotationFieldsService = quotationFieldsService;
    }

    public async override Task<bool> HasReferences(QuotationCloseReasonModel entity)
    {
        return await _quotationFieldsService.ExistsAsync(q => q.QuotationCloseReasonId == entity.Id);
    }
}