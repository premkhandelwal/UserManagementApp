using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;
using FluentValidation;

public class MtcTypeService : BaseService<CreateMtcTypeRequest, MtcTypeModel>
{
    public MtcTypeService(IMapper mapper, BaseRepository<MtcTypeModel> repository, IValidator<CreateMtcTypeRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}