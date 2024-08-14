using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;
using FluentValidation;

public class MemberService : BaseService<CreateMemberRequest, MemberModel>
{
    public MemberService(IMapper mapper, BaseRepository<MemberModel> repository, IValidator<CreateMemberRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}