using AutoMapper;
using Crm.Tenant.Data.Models.Masters;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Service.Models.Requests.Material.CreateMaterial;
using FluentValidation;

public class MaterialService : BaseService<CreateMaterialRequest, MaterialModel>
{
    public MaterialService(IMapper mapper, BaseRepository<MaterialModel> repository, IValidator<CreateMaterialRequest> validator)
        : base(mapper, repository, validator)
    {
    }
}