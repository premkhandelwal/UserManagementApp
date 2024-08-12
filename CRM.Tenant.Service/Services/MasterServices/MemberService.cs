using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.Member.CreateMember;
using FluentValidation;

public class MemberService : BaseService<CreateMemberRequest, MemberModel>
{
    public MemberService(IMapper mapper, BaseRepository<MemberModel> repository, IValidator<CreateMemberRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}