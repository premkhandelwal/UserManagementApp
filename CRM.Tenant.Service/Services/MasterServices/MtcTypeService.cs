using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.MtcType.CreateMtcType;
using FluentValidation;

public class MtcTypeService : BaseService<CreateMtcTypeRequest, MtcTypeModel>
{
    public MtcTypeService(IMapper mapper, BaseRepository<MtcTypeModel> repository, IValidator<CreateMtcTypeRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}