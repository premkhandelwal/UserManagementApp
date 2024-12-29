using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Services.QuotationService;
using FluentValidation;

public class MemberService : BaseService<CreateMemberRequest, MemberModel>
{
    QuotationFieldsService _quotationFieldsService;
    public MemberService(IMapper mapper, BaseRepository<MemberModel> repository, IValidator<CreateMemberRequest> validator, QuotationFieldsService quotationFieldsService)
        : base(mapper, repository, validator)
    {
        _quotationFieldsService = quotationFieldsService;
    }

    public async override Task<bool> HasReferences(MemberModel entity)
    {
        return await _quotationFieldsService.ExistsAsync(p => p.QuotationAttentionId == entity.Id);
    }
}